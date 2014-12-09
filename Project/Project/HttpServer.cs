using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Project
{
    class HttpServer : IDisposable
    {
        //class attributes
        //using readoly prevent someone acidentally changing the value
        private readonly HttpListener listener;
        private readonly Thread listenerThread;
        private readonly ManualResetEvent stop;
        private readonly AutoResetEvent listenForNextRequest = new AutoResetEvent(false);
        private readonly String serverUrl;
        ServerForm myFormContrl;
        GameEngine game;
        public bool gameIsRuning = false;
        List<KeyValuePair<string, HttpListenerContext>> myClientList;

        public HttpServer(ServerForm myForm)
        {
            listener = new HttpListener();
            listenerThread = new Thread(HandleRequests);
            stop = new ManualResetEvent(false);
            myFormContrl = myForm;
            game = new GameEngine(myFormContrl);
            serverUrl = LocalIPAddress();
            myClientList = new List<KeyValuePair<string, HttpListenerContext>>();
        }

        public void Start()
        {
            try
            {
                if (!listener.IsListening)
                {
                    listener.Prefixes.Add("http://" + serverUrl);
                    listener.Start();
                    listenerThread.Start();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void HandleRequests()
        {
            while (listener.IsListening)
            {
                var context = listener.BeginGetContext(ListenerCallback, listener);

                //wait for a signal to get out the loop and end thread
                if (0 == WaitHandle.WaitAny(new[] { stop, context.AsyncWaitHandle }))
                {
                    return;
                }
                listenForNextRequest.WaitOne();
            }
        }

        private void ListenerCallback(IAsyncResult ar)
        {
            HttpListener h1 = ar.AsyncState as HttpListener;
            HttpListenerContext context = null;

            if (h1 == null)
            {
                return;
            }

            try
            {
                //Bocks ntil there is a request to be processed
                context = h1.EndGetContext(ar);
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                //Once we know we have a request, we signal the other thread so that
                //it calls the GeginGetContext() to start handling a new thread
                listenForNextRequest.Set();
            }

            if (context == null)
            {
                return;
            }

            ProcessRequest(context);
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            string requestDate = GetRequestString(request);
            string clientName = ExtractTaskMessage(requestDate, "myName");

            if (requestDate.Contains("logIn"))
            {
                
                bool isClientExist = FindClient(clientName);
                if(isClientExist)
                {
                    WriteResponse(context, "client already existed");
                }
                else
                {
                    WriteResponse(context, "welcome");
                }
            }
            else if (requestDate.Contains("ready"))
            {
                clientName = ExtractTaskMessage(requestDate, "myName");
                AddClient(context, clientName);
            }
            else if (requestDate.Contains("answer"))
            {
                string answer = ExtractTaskMessage(requestDate, "answer");

                if (answer == game.result.ToString())
                {
                    WriteResponse(context, "t");
                }
                else
                {
                    WriteResponse(context, "f");
                }
            }
            myFormContrl.Invoke(myFormContrl.showTextDelegate, new Object[] { requestDate });
        }

        private string GetRequestString(HttpListenerRequest request)
        {
            if (request.HasEntityBody)
            {
                using (StreamReader sr = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestDate = sr.ReadToEnd();
                    return requestDate;
                }
            }
            return null;
        }

        public void Dispose()
        {
            Stop();
        }

        public void Stop()
        {
            stop.Set();
            listenerThread.Join();
            listener.Stop();
        }

        private void WriteResponse(HttpListenerContext context, string responseString)
        {
            //get a response object
            using (HttpListenerResponse response = context.Response)
            {
                //construct response
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.LongLength;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }

        public void GameStart()
        {
            gameIsRuning = true;
            game.SwitchQuestions();
            gameIsRuning = false;
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            localIP += ":8081/";
            return localIP;
        }

        private string ExtractTaskMessage(string content, string target)
        {
            string answer;

            //get the position of answer
            int pos = content.IndexOf(target + "=");
            string temp = content.Substring(pos + target.Length+1);
            int pos2 = temp.IndexOf("&");
            if (pos2 < 0)
            {
                answer = temp;
            }
            else
            {
                answer = temp.Substring(0, pos2);
            }
            return answer;
        }

        private bool FindClient(string clientName)
        {
            bool exist = false;

            foreach (KeyValuePair<string, HttpListenerContext> kvp in myClientList)
            { 
                if(kvp.Key == clientName)
                {
                    exist = true;
                }
            }
            
            return exist;
        }

        private void AddClient(HttpListenerContext context, string clientName)
        {
            myClientList.Add(new KeyValuePair<string, HttpListenerContext>(clientName, context));           
        }

        private void DeleteClient(string clientName)
        {

        }
    }
}
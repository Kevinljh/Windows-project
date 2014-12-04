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

namespace Project
{
    class HttpServer:IDisposable
    {
        //class attributes
        //using readoly prevent someone acidentally changing the value
        private readonly HttpListener listener;
        private readonly Thread listenerThread;
        private readonly ManualResetEvent stop;
        private readonly AutoResetEvent listenForNextRequest = new AutoResetEvent(false);
        ServerForm myFormContrl;
        GameEngine game;

        public HttpServer(ServerForm myForm)
        {
            listener = new HttpListener();
            listenerThread = new Thread(HandleRequests);
            stop = new ManualResetEvent(false);
            myFormContrl = myForm;
            game = new GameEngine(myFormContrl);
        }

        public void Start()
        {
            try
            {
                if(!listener.IsListening)
                {

                    listener.Prefixes.Add("http://10.113.21.154:8091/");                    
                    listener.Start();
                    listenerThread.Start();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void HandleRequests()
        {
            while(listener.IsListening)
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

            if(h1 == null)
            {
                return;
            }

            try
            {
                //Bocks ntil there is a request to be processed
                context = h1.EndGetContext(ar);

            }
            catch(Exception ex)
            {
                return;
            }
            finally
            {
                //Once we know we have a request, we signal the other thread so that
                //it calls the GeginGetContext() to start handling a new thread
                listenForNextRequest.Set();
            }

            if(context == null)
            {
                return;
            }

            ProcessRequest(context);
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            string requestDate = GetRequestString(request);
            if(requestDate == game.result.ToString().ToLower())
            {
                WriteResponse(context, "t");
            }
            else
            {
                WriteResponse(context, "f");
            }
            myFormContrl.Invoke(myFormContrl.showTextDelegate, new Object[] { requestDate });
            //WriteResponse(context, "Hi there");
        }

        private string GetRequestString(HttpListenerRequest request)
        {
            if(request.HasEntityBody)
            {
                using(StreamReader sr = new StreamReader(request.InputStream, request.ContentEncoding))
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
            using(HttpListenerResponse response = context.Response)
            {
                //construct response
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.LongLength;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }

        public void GameStart()
        {
            //for (int i = 0; i < 10; i++)
            //{
                game.SwitchQuestions();
                //Thread.Sleep(500);
            //}
        }
    }
}

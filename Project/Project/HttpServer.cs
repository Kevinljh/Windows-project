﻿/*
* FILE          : HttpServer.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : Mine Game server HttpServer class file. This class hanles all the connection 
 *                between the server and client
*/
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
using System.Collections;
using System.Net.Sockets;

namespace Project
{
    public class HttpServer : IDisposable
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
        List<Client> myClientList; 
        public delegate void UpdateClientList(List<Client> clientList);
        public UpdateClientList UpdateClientListDelegate;
        public int CategoryId { set; get; }

        // NAME     :   HttpServer()
        // PURPOSE  :   Constructor that takes one params, which is the control of the form
        public HttpServer(ServerForm myForm)
        {          
            listener = new HttpListener();
            listenerThread = new Thread(HandleRequests);
            stop = new ManualResetEvent(false);
            myFormContrl = myForm;
            //game = new GameEngine(myFormContrl, this, categoryId);
            myClientList = new List<Client>();
            serverUrl = LocalIPAddress();
        }

        // NAME     :   Start()
        // PURPOSE  :   Start listner to listen for client request
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
                Console.WriteLine(ex.Message);
            }
        }

        // NAME     :   HandleRequests()
        // PURPOSE  :   Handle requests ansynchornonsly
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

        // NAME     :   ListenerCallback()
        // PURPOSE  :   Listener call back function, when it gets the context, this function will fire up
        //              after getting the context, it calls the processor to processes request
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

        // NAME     :   ProcessRequest()
        // PURPOSE  :   Process the request acorrding to the client requests
        private void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            string requestDate = GetRequestString(request);
            string clientRequestTask = ExtractTaskMessage(requestDate, "myTask");
            string clientName = ExtractTaskMessage(requestDate, "myName");
            bool isClientExist = FindClient(clientName);

            //get the log in message when a new client comes in
            if (clientRequestTask == "logIn")
            {                              
                if(isClientExist)
                {
                    WriteResponse(context, "client already existed");
                }
                else if(gameIsRuning)
                {
                    WriteResponse(context, "please wait for next game");  
                }
                else
                {
                    WriteResponse(context, "welcome");
                }
            }
            else if (clientRequestTask == "ready")
            {
                if (!isClientExist)
                {
                    //new client that needs to add the client table
                    AddClient(context, clientName);
                }
            }
            else if (clientRequestTask == "answer")
            {
                //get clients answer and then check if the answer is right
                string answer = ExtractTaskMessage(requestDate, "myAnswer");
                if (gameIsRuning)
                {
                    //respose result
                    if (answer == game.currentQuestion.Answer.Substring(0, 1))
                    {
                        //retrive table finds the client and increase the score when the answer is right
                        foreach (Client kvp in myClientList)
                        {
                            if (kvp.Name == clientName)
                            {
                                kvp.Score++;
                            }
                        }
                        //update ui
                        updateClientList();
                        WriteResponse(context, "t");
                    }
                    else
                    {
                        WriteResponse(context, "f");
                    }
                }
            }
            else if(clientRequestTask == "question")
            {
                foreach (Client client in myClientList)
                {
                    if (client.Name == clientName)
                    {
                        client.Context = context;
                    }
                }
            }
            Console.WriteLine(requestDate);
        }

        // NAME     :   GetRequestString()
        // PURPOSE  :   Decode the context, extract what is in the request context
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

        // NAME     :   Dispose()
        // PURPOSE  :   Stop the running threads
        public void Dispose()
        {
            Stop();
        }

        // NAME     :   Stop()
        // PURPOSE  :   Stop listen for new request
        public void Stop()
        {
            //stop listening
            stop.Set();
            listenerThread.Join();
            listener.Stop();                     
        }

        // NAME     :   StopGame()
        // PURPOSE  :   Stop the game engine
        public void StopGame()
        {
            //stop current game
            myFormContrl.EndGame();
            gameIsRuning = false;
        }

        // NAME     :   WriteResponse()
        // PURPOSE  :   Write response to the client with specific message
        private void WriteResponse(HttpListenerContext context, string responseString)
        {
            try
            {
                //get a response object
                using (HttpListenerResponse response = context.Response)
                {
                    //construct response
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.LongLength;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
                context.Response.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // NAME     :   GameStart()
        // PURPOSE  :   Game start switch questions on the ui
        public void GameStart()
        {
            gameIsRuning = true;
            game = new GameEngine(myFormContrl, this, CategoryId);
            game.SwitchQuestions();
            gameIsRuning = false;
        }

        // NAME     :   SendQuestoin()
        // PURPOSE  :   Send the questions to client
        public void SendQuestoin()
        {           
            foreach (Client client in myClientList)
            {
                string optionStr = "";
                if (game.currentQuestion.Content != "Game Over.")
                {
                    foreach (Option option in game.Options)
                    {

                        optionStr += option.OptionName;
                        optionStr += "\n";
                    }
                    WriteResponse(client.Context, game.currentQuestion.Content + "\n" + optionStr);
                }
                else
                {
                    WriteResponse(client.Context, "end" );
                    myClientList.Clear();
                    break;
                }
               
            }
        }

        // NAME     :   ExtractTaskMessage()
        // PURPOSE  :   Extract the client request and check what are they name and task
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

        // NAME     :   FindClient()
        // PURPOSE  :   Check if the client is already exist in the client table
        private bool FindClient(string clientName)
        {
            bool exist = false;

            foreach (Client kvp in myClientList)
            { 
                if(kvp.Name == clientName)
                {
                    exist = true;
                }
            }
            
            return exist;
        }

        // NAME     :   AddClient()
        // PURPOSE  :   Add new client to list
        private void AddClient(HttpListenerContext context, string clientName)
        {
            Client temp = new Client();
            temp.Name =clientName;
            temp.Context = context;
            temp.Score = 0;
            myClientList.Add(temp);
            updateClientList();
        }

        // NAME     :   updateClientList()
        // PURPOSE  :   Invoke ui
        private void updateClientList()
        {
            myClientList.Sort();
            myFormContrl.Invoke(myFormContrl.UpdateClientListDelegate, new Object[] { myClientList });
             
        }

        // NAME     :   DeleteClient()
        // PURPOSE  :   Delete client
        private void DeleteClient(string clientName)
        {
            myClientList.Clear();
        }

        // NAME     :   LocalIPAddress()
        // PURPOSE  :   Get local IP address
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

    }
}
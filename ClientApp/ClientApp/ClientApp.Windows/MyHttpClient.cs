/*
* FILE          : MyHttpClient.xaml.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This file contains MyHttpClient class which is inherited for httpClient. It creates the http requests and
*                 deal with the responses. When it gets the response it would update ui
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Net;
using Windows.UI.Xaml.Controls;

namespace ClientApp
{
    class MyHttpClient: HttpClient, INotifyPropertyChanged
    {
        HttpResponseMessage myResponseMsg;
        HttpContent requestContent;
        //store the data that will be sent to server
        List<KeyValuePair<string, string>> postData;
        public int scoreCounter = 0;
        string score = "0";
        //data banding handler
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly String serverUrl;
        public readonly string myName;
        public int logInError;
        public MainPage myMainPage;

        // NAME     :   MyHttpClient()
        // PURPOSE  :   Constructor that takes two params. One is the server ip from user. The other one is user name that will be
        //              a identifier sent to server.
        public MyHttpClient(string serverIP, string name)
        {
            postData = new List<KeyValuePair<string, string>>();
            serverUrl = "http://" + serverIP + "/";
            myName = name;          
        }

        // NAME     :   scoreProperty
        // PURPOSE  :   Score property that's used to set and get the value of score
        public string scoreProperty
        {
            get { return score; }
            set
            {
                score = value;
                NotifyPropertyChanged("scoreProperty");
            }
        }

        // NAME     :   NotifyPropertyChanged
        // PURPOSE  :   Notify is changed and then update the ui with the date binding field
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // NAME     :   logInRequest
        // PURPOSE  :   Send a log in resquest to server, expert a "welcome" message from server
        public void logInRequest()
        {
            logInError = 0;
            postData.Clear();
            //add the pair  message in the list and send to server
            postData.Add(new KeyValuePair<string, string>("myTask", "logIn"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            requestContent = new FormUrlEncodedContent(postData);
            logInSendRequest();            
        }

        // NAME     :   sendReady
        // PURPOSE  :   Send a request and tell server he is ready to play 
        public void sendReady()
        {
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "ready"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            requestContent = new FormUrlEncodedContent(postData);
            sendRequest();
        }

        // NAME     :   sendQuestionRequest
        // PURPOSE  :   Ask server for a new question, so that it can be display on the screen
        public void sendQuestionRequest()
        {
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "question"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            requestContent = new FormUrlEncodedContent(postData);
            logInSendRequest();
        }

        // NAME     :   sendAnwser
        // PURPOSE  :   Send awser to server and see if the answer is correct or not
        public void sendAnwser(string answer)
        {
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "answer"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            postData.Add(new KeyValuePair<string, string>("myAnswer", answer));
            requestContent = new FormUrlEncodedContent(postData);
            sendRequest();
        }

        // NAME     :   logInSendRequest
        // PURPOSE  :   Send a log in resquest to server, expert a "welcome" message from server
        //              send request with sync, so ui can notice error
        public async void logInSendRequest()
        {
            try
            {
                myResponseMsg = base.PostAsync(serverUrl, requestContent).Result;

                //wait for respose
                string content = await myResponseMsg.Content.ReadAsStringAsync();
                dealResponseContent(content);
            }
            catch (Exception e)
            {
                logInError = 1;
            }
        }

        // NAME     :   sendRequest
        // PURPOSE  :   Send request with async, so it would not block the ui
        public async void sendRequest()
        {
            try
            {
                myResponseMsg = await base.PostAsync(serverUrl, requestContent);

                //wait for respose
                string content = await myResponseMsg.Content.ReadAsStringAsync();
                dealResponseContent(content);
            }
            catch(Exception e)
            {
                logInError = 1;
            }
        }

        // NAME     :   dealResponseContent
        // PURPOSE  :   Check all the response out and do the specific task
        private void dealResponseContent(string content)
        {
            if (content == "client already existed")
            {
                logInError = 1;
            }
            else if(content =="please wait for next game")
            {
                logInError = 2;
            }
            else if (content == "welcome")
            {
                //do nothing, just want server know this client is there
            }
            //get return t/f(true/false) from server
            //increse score
            else if (content == "t")
            {
                myMainPage.ResultMessage("BINGO! YOU'RE AWESOME!");
                scoreCounter++;
                scoreProperty = scoreCounter.ToString();
            }   
            else if (content == "f")
            {
                myMainPage.ResultMessage("OH NO! YOU ARE WRONG!");
            }
            //when the game is end, it display game over to the screen
            else if(content == "end")
            {
                myMainPage.questionTB.Text = "Game Over";
                myMainPage.nextGameBtn.IsEnabled = true;
                myMainPage.TimerStop();
                myMainPage.Disable();
                myMainPage.gameIsRuning = false;
            }
                //this is the questions
            else
            {
                myMainPage.ShowQuestion(content);
                myMainPage.TimerStart();
                myMainPage.ResultMessage("");
                myMainPage.gameIsRuning = true;
            }
        }
    }
}

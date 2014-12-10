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
        List<KeyValuePair<string, string>> postData;
        public int scoreCounter = 0;
        string score = "0";
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly String serverUrl;
        public readonly string myName;
        public int logInError;
        public MainPage myMainPage;

        public MyHttpClient(string serverIP, string name)
        {
            postData = new List<KeyValuePair<string, string>>();
            serverUrl = "http://" + serverIP + "/";
            myName = name;
        }

        public string scoreProperty
        {
            get { return score; }
            set
            {
                score = value;
                NotifyPropertyChanged("scoreProperty");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void logInRequest()
        {
            logInError = 0;
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "logIn"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            requestContent = new FormUrlEncodedContent(postData);
            logInSendRequest();            
        }

        public void sendReady()
        {
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "ready"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            requestContent = new FormUrlEncodedContent(postData);
            sendRequest();
        }

        public void sendQuestionRequest()
        {
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "question"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            requestContent = new FormUrlEncodedContent(postData);
            logInSendRequest();
        }

        public void sendAnwser(string answer)
        {
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "answer"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            postData.Add(new KeyValuePair<string, string>("myAnswer", answer));
            requestContent = new FormUrlEncodedContent(postData);
            sendRequest();
        }

        //send request with sync, so ui can notice error
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
                myMainPage.messageTB.Text = "Please wait for everybody";
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
                myMainPage.ResultMessage("OH NO! YOU SUCK!");
            }
            else if(content == "end")
            {
                myMainPage.questionTB.Text = "Game Over";
                myMainPage.nextGameBtn.IsEnabled = true;
            }
            else
            {
                myMainPage.ShowQuestion(content);
                myMainPage.TimerStart();
            }
        }

        private string ExtractTaskMessage(string content, string target)
        {
            string answer;

            //get the position of answer
            int pos = content.IndexOf(target + "=");
            string temp = content.Substring(pos + target.Length + 1);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Xaml;
using System.ComponentModel;

namespace ClientApp
{
    class MyHttpClient: HttpClient, INotifyPropertyChanged
    {
        HttpResponseMessage myResponseMsg;
        HttpContent requestContent;
        List<KeyValuePair<string, string>> postData;
        public int scoreCounter = 0;
        string score;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //public String serverUrl = "http://10.113.21.154:8081/";
        private readonly String serverUrl;
        public readonly string myName;

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
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "logIn"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            requestContent = new FormUrlEncodedContent(postData);
            sendRequest();
        }

        public void sendAnwser(string answer)
        {
            postData.Clear();
            postData.Add(new KeyValuePair<string, string>("myTask", "answer"));
            postData.Add(new KeyValuePair<string, string>("myName", myName));
            postData.Add(new KeyValuePair<string, string>("answer", answer));
            requestContent = new FormUrlEncodedContent(postData);
            sendRequest();
        }

        public async void sendRequest()
        {
            myResponseMsg = await base.PostAsync(serverUrl, requestContent);
            string content = await myResponseMsg.Content.ReadAsStringAsync();
            dealResponseContent(content);
        }

        private void dealResponseContent(string content)
        {
            //get return t/f(true/false) from server
            //increse score
            if (content == "t")
            {
                scoreCounter++;
                scoreProperty = scoreCounter.ToString();
            }
        }
    }
}

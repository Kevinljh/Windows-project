using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ServerForm : Form
    {
        public delegate void ShowText(String myString);
        public delegate void ChangeQuestion(Color foreColor, string text);
        public ShowText showTextDelegate;
        public ChangeQuestion changeQuestionDelegate;
        HttpServer server;

        Thread gameThread;

        public ServerForm()
        {
            InitializeComponent();
            showTextDelegate = new ShowText(ShowTextMethod);
            changeQuestionDelegate = new ChangeQuestion(ChangeQuestionMethod);
            server = new HttpServer(this);
            IPAdressLB.Text = "IP:" + server.LocalIPAddress().TrimEnd('/');
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!server.gameIsRuning)
            {
                gameThread = new Thread(new ThreadStart(server.GameStart));
                gameThread.Start();
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            server.Stop();
        }


        public void ShowTextMethod(string myString)
        {
            //MainTextBox.Text = MainTextBox.Text + "\n" + myString;
            MainTextBox.Text = myString;
        }
        public void ChangeQuestionMethod(Color foreColor, string text)
        {
            TestLable.ForeColor = foreColor;
            TestLable.Text = text;
        }
        private void ListenBtn_Click(object sender, EventArgs e)
        {
            server.Start();
        }
    }
}

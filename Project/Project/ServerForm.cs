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
        GameEngine game;

        Thread gameThread;

        public ServerForm()
        {
            InitializeComponent();
            showTextDelegate = new ShowText(ShowTextMethod);
            changeQuestionDelegate = new ChangeQuestion(ChangeQuestionMethod);
            server = new HttpServer(this);
            game = new GameEngine(this);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            server.Start();
            gameThread = new Thread(new ThreadStart(game.SwitchQuestions));          
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            server.Stop();
        }


        public void ShowTextMethod(string myString)
        {
            MainTextBox.Text = MainTextBox.Text + "\n" + myString;
        }
        public void ChangeQuestionMethod(Color foreColor, string text)
        {
            TestLable.ForeColor = foreColor;
            TestLable.Text = text;
        }
    }
}

/*
* FILE          : ServerForm.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This is form class which is the ui of the server. All the class object are created in this class
 *                and pass though the program
*/
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
        public delegate void ChangeQuestion(Question foreColor, List<Option> optionList);
        public delegate void UpdateClientList(List<Client> clientList);
        public ShowText showTextDelegate;
        public ChangeQuestion changeQuestionDelegate;
        public HttpServer server;
        public UpdateClientList UpdateClientListDelegate; 
        BindingSource source;
        Thread gameThread;
        DBAccessor db = new DBAccessor();
        List<Category> categoryList;
        int categoryId = -1;

        // NAME     :   ServerForm()
        // PURPOSE  :   Get all the attribute value in this constructor
        public ServerForm()
        { 
            InitializeComponent();

            categoryList = db.GetAllCategories();
            foreach (Category c in categoryList)
            {
                ToolStripMenuItem newChild = new ToolStripMenuItem();
                newChild.Text = c.Name; 
                newChild.Click += new System.EventHandler(this.StartGame_Click);
                this.categoryDropDownButton.DropDownItems.Add(newChild);
            }
                
            showTextDelegate = new ShowText(ShowTextMethod);
            changeQuestionDelegate = new ChangeQuestion(ChangeQuestionMethod);
            UpdateClientListDelegate = new UpdateClientList(UpdateClientListMethod);
            server = new HttpServer(this);
            IPAdressLB.Text = server.LocalIPAddress();
            source = new BindingSource();
            clientGridView.DataSource = source;
            server.Start();
        }

        // NAME     :   StartGame_Click()
        // PURPOSE  :   Create a thread to run the game engine
        private void StartGame_Click(object sender, EventArgs e)
        {           
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            foreach (Category category in categoryList)
            {
                if (category.Name == item.Text)
                {
                    categoryId = category.ID;
                    break;
                }
            }
            server.CategoryId = categoryId;
            if (!server.gameIsRuning)
            {               
                gameThread = new Thread(new ThreadStart(server.GameStart));
                gameThread.Start();
            }
        }

        // NAME     :   StopBtn_Click()
        // PURPOSE  :   Stop the game during the excution
        private void StopBtn_Click(object sender, EventArgs e)
        {
            server.StopGame();
            ATextBox.Text = "";
            BTextBox.Text = "";
            CTextBox.Text = "";
            DTextBox.Text = "";
            MainTextBox.Text = "";
        }

        // NAME     :   ShowTextMethod()
        // PURPOSE  :   This is a delegate handler function
        public void ShowTextMethod(string myString)
        {
            MainTextBox.Text = myString;
        }

        // NAME     :   EndGame()
        // PURPOSE  :   Stop the game engine
        public void EndGame()
        {
            if (gameThread != null)
            {
                gameThread.Abort();
            }
        }

        // NAME     :   UpdateClientListMethod()
        // PURPOSE  :   Update the rank
        public void UpdateClientListMethod(List<Client> clientList)
        {
            source.DataSource = clientList;
            source.ResetBindings(false);
        }

        // NAME     :   ChangeQuestionMethod()
        // PURPOSE  :   Switch questions
        public void ChangeQuestionMethod(Question question, List<Option>optionList)
        {
            
            MainTextBox.Text = question.Content;

            foreach (Option option in optionList)
            {
                if (option.OptionName.StartsWith("a"))
                {
                    if (option.OptionName.IndexOf("a-") >= 0)
                    {
                        ATextBox.Text = option.OptionName.Substring(2, option.OptionName.Length-2);
                    }
                    else
                    {
                        ATextBox.Text = option.OptionName;
                    }
                    
                }
                else if(option.OptionName.StartsWith("b")) 
                {
                    if (option.OptionName.IndexOf("b-") >= 0)
                    {
                        BTextBox.Text = option.OptionName.Substring(2, option.OptionName.Length-2);
                    }
                    else
                    {
                        BTextBox.Text = option.OptionName;
                    }
                   
                }
                else if(option.OptionName.StartsWith("c"))
                {
                    if (option.OptionName.IndexOf("c-") >= 0)
                    {
                        CTextBox.Text = option.OptionName.Substring(2, option.OptionName.Length-2);
                    }
                    else
                    {
                        CTextBox.Text = option.OptionName;
                    }
                }
                else if (option.OptionName.StartsWith("d"))
                {
                    if (option.OptionName.IndexOf("d-") >= 0)
                    {
                        DTextBox.Text = option.OptionName.Substring(2, option.OptionName.Length-2);
                    }
                    else
                    {
                        DTextBox.Text = option.OptionName;
                    }
                }
            }
        }

        // NAME     :   SettingStripLabel_Click()
        // PURPOSE  :   Go to the data base
        private void SettingStripLabel_Click(object sender, EventArgs e)
        {
            Form settingForm = new SettingForm(this);
            settingForm.Show();
            this.Hide(); 
        }

        // NAME     :   ServerForm_FormClosing()
        // PURPOSE  :   Client up everthing when close the program
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            if (gameThread != null)
            {
                //not a good way the handler thread
                gameThread.Abort();
            }
        }     
    }
}
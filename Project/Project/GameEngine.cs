/*
* FILE          : GameEngine.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This game engine is user the get the question for the server and send the game message to
 *                client though http server class
*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace Project
{
    class GameEngine
    {
        ServerForm myFormContrl;
        Random rnd = new Random();
        private List<Question> questions;
        public List<Option> Options { set; get; }
        private DBAccessor dbAccessor;
        private int categoryId = 1;
        public Question currentQuestion;
        HttpServer myServer;

        // NAME     :   GameEngine()
        // PURPOSE  :   Constructor
        public GameEngine(ServerForm myForm, HttpServer myServer, int pcategoryId)
        {
            myFormContrl = myForm;
            dbAccessor = new DBAccessor();
            this.categoryId = pcategoryId;
            questions = dbAccessor.GetQuestions(categoryId);
            this.myServer = myServer;
        }

        // NAME     :   SwitchQuestions()
        // PURPOSE  :   Switch question every 20 sec
        public void SwitchQuestions()
        {
            foreach (Question question in questions)
            {
                currentQuestion = question;
                this.Options = dbAccessor.GetOptions(question.ID);
                myFormContrl.Invoke(myFormContrl.changeQuestionDelegate, new Object[] { question, Options });
                myServer.SendQuestoin();
                //wait for some time
                Thread.Sleep(12000);
            }
            Question temp = new Question();
            temp.Content = "Game Over.";
            currentQuestion = temp;
            int i = 0;
            //clean options in UI
            foreach (Option option in Options)
            {
                if (i == 0)
                {
                    option.OptionName = "a-";
                }

                if (i == 1)
                {
                    option.OptionName = "b-";
                }

                if (i == 2)
                {
                    option.OptionName = "c-";
                }

                if (i == 3)
                {
                    option.OptionName = "d-";
                }
                i++;
            }
            myFormContrl.Invoke(myFormContrl.changeQuestionDelegate, new Object[] { temp, Options });
            myServer.SendQuestoin();
        }
    }
}
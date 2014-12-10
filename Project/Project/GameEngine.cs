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
        List<QuestionRepository> myQuestionRespository;
        Random rnd = new Random();
        private List<Question> questions;
        public List<Option> Options{set; get;}
        private DBAccessor dbAccessor;
        private int categoryId = 1;
        public Question currentQuestion;
        HttpServer myServer;
        //signal r
        //myFormContrl.Invoke(myFormContrl.showTextDelegate, new Object[] { requestDate });
        public GameEngine(ServerForm myForm, HttpServer myServer, int pcategoryId)
        {
            myFormContrl = myForm;
            myQuestionRespository = new List<QuestionRepository>();
            GenerateQuestionRepository();
            dbAccessor = new DBAccessor();
            this.categoryId = pcategoryId;
            questions = dbAccessor.GetQuestions(categoryId);
            this.myServer = myServer;
        }

        public void SwitchQuestions()
        {       
            foreach (Question question in questions)
            {
                
                currentQuestion = question;
                this.Options = dbAccessor.GetOptions(question.ID);
                myFormContrl.Invoke(myFormContrl.changeQuestionDelegate, new Object[] { question, Options });
                myServer.SendQuestoin();
                Thread.Sleep(12000);
            }
            Question temp = new Question();
            temp.Content = "Game Over.";
            currentQuestion = temp;
            int i = 0;
            //clean options in UI
            foreach (Option option in Options){
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


        private void GenerateQuestionRepository()
        {
            QuestionRepository q1 = new QuestionRepository();
            QuestionRepository q2 = new QuestionRepository();
            QuestionRepository q3 = new QuestionRepository();
            QuestionRepository q4 = new QuestionRepository();
            QuestionRepository q5 = new QuestionRepository();

            q1.foreColor = Color.Blue;
            q1.text = Color.Blue.ToString();
            q1.answer = true;

            q2.foreColor = Color.Red;
            q2.text = Color.Yellow.ToString();
            q2.answer = false;

            q3.foreColor = Color.Yellow;
            q3.text = Color.Blue.ToString();
            q3.answer = false;

            q4.foreColor = Color.Green;
            q4.text = Color.Green.ToString();
            q4.answer = true;

            q5.foreColor = Color.Black;
            q5.text = Color.Black.ToString();
            q5.answer = false;

            myQuestionRespository.Add(q1);
            myQuestionRespository.Add(q2);
            myQuestionRespository.Add(q3);
            myQuestionRespository.Add(q4);
            myQuestionRespository.Add(q5);
        }
    }

    public 

    class QuestionRepository
    {
        public Color foreColor;
        public string text;
        public bool answer;

        public Color GetForeColor()
        {
            return foreColor;
        }
        public string GetText()
        {
            return text;
        }
        public bool GetAnswer()
        {
            return answer;
        }
    }
}
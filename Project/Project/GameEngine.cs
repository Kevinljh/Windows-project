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
        public bool result;
        private List<Question> questions;
        private List<Option> options;
        private DBAccessor dbAccessor;
        private int categoryId = 1;
        //signal r
        //myFormContrl.Invoke(myFormContrl.showTextDelegate, new Object[] { requestDate });
        public GameEngine(ServerForm myForm)
        {
            myFormContrl = myForm;
            myQuestionRespository = new List<QuestionRepository>();
            GenerateQuestionRepository();
            dbAccessor = new DBAccessor();
            questions = dbAccessor.GetQuestions(categoryId);

        }

        public void SwitchQuestions()
        {
           
            foreach (Question question in questions)
            {

                this.options = dbAccessor.GetOptions(question.ID);
                myFormContrl.Invoke(myFormContrl.changeQuestionDelegate, new Object[] { question, options });

                Thread.Sleep(3000);
            }

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
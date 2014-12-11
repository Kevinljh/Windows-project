/*
* FILE          : Question.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This is container class that has the the quesiotns attrutes which are from the database
 *                
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Question
    {
        public int ID { set; get; }
        public string Content { set; get; }
        public string Type { set; get; }
        public string Answer { set; get; }
        public int CategoryID {set; get; }

    }
}

/*
* FILE          : Option.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This class is to help access the data base. So that the program know which table it needs to access
 *                
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
   public class Option
    {
        public int ID { set; get; }
        public int QuestionID { set; get; }
        public string OptionName { set; get; }
    }
}

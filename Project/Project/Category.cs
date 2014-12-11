/*
* FILE          : Option.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This class is to help access the data base. So that the user can pick what game do they what to play.
 *                They can also pick the server
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Category
    {
        public int ID { set; get; }

        public string Type { set; get; }

        public string Name { set; get; } 

    }
}

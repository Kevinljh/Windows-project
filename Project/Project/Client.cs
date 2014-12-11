/*
* FILE          : Client.cs
* PROJECT       : PROG2120 - Windows and Mobile Programming - final Project
* PROGRAMMER    : Kevin Li, Bowen Zhuanj, Michael Da Silva
* FIRST VERSION : 2014-12-06
* DESCRIPTION   : This container class store the client's information
 *                
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
namespace Project
{
    public class Client : IComparable
    { 
        public string Name{set; get;}

        [Browsable(false)]
        public HttpListenerContext Context { set; get; }
        public int Score { set; get; }


        public int CompareTo(object obj)
        {
            int result = 0;
            Client c = (Client) obj;
            result = c.Score - this.Score;
            return result;

        }
    }
}

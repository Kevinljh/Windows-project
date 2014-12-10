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

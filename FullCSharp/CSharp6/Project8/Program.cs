using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Console;
namespace Project8
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(GetTime());
            ReadLine();
        }
        public static string GetTime()=> "Current Time - " + DateTime.Now.ToString("hh:mm:ss");
       
    }
}

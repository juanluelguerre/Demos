using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Convert;
using System.Console;
namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter first value ");
            int val1 = ToInt32(ReadLine());
            WriteLine("Enter next value ");
            int val2 = ToInt32(ReadLine());
            WriteLine("sum : {0}", (val1+val2));
            ReadLine();
        }
    }
}

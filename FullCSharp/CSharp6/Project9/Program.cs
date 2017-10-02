using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Console;
namespace Project9
{
    class Program
    {
        static void Main()
        {
            string FirstName = "Nitin";
            string LastName = "Pandit";

            // With String Interpolation in C# 6.0
            string  output= "\{FirstName}-\{LastName}";
            WriteLine(output);
            ReadLine();
        }
    }
}

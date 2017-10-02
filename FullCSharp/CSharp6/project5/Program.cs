using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace project5
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = 0;
            int val2 = 0;
            try
            {
                WriteLine("Enter first value :");
                val1 = int.Parse(ReadLine());
                WriteLine("Enter Next value :");
                val2 = int.Parse(ReadLine());
                WriteLine("Div : {0}", (val1 / val2));
            }
            catch (Exception ex) if (val2 == 0)
            {
                WriteLine("Can't be Division by zero ☺");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            ReadLine();
        }
    }
}

using ElGuerre.Demos.CalculartorConsole;
using System;

namespace CalculatorCoreConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            double result = 0;
            string operation = args[0];
            int value1 = int.Parse(args[1]);
            int value2 = int.Parse(args[2]);


            CalculatorAutoProperties c2 = new CalculatorAutoProperties(1,3);
            //c2.Value1 = 1;
            // c2.Value3 = 3;
            // c2.Value33 = 33;
            // c2.Value4 = 44;

            Console.WriteLine("TOTAL: {0}", c2.Suma);



            // if (operation.ToLower() == "suma")
            //{
            //    result = c.Sum(value1, value2);
            //}
            //else if (operation.ToLower() == "divide")
            //{
            //    result = c.Divide(value1, value2);
            //}
            //Console.WriteLine($"Resultado: {result}");            

            Console.WriteLine("Pulse INTRO para finalizar...");
            Console.ReadLine();
        }
    }
}
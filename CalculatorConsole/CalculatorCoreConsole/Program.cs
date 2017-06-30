using ElGuerre.Demos.CalculartorConsole;
using System;

namespace CalculatorCoreConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            double result = 0;
            string operation = args[1];
            int value1 = int.Parse(args[2]);
            int value2 = int.Parse(args[3]);


            Calculator c = new Calculator();
            if (operation.ToLower() == "suma")
            {
                result = c.Sum(value1, value2);
            }
            else if (operation.ToLower() == "divide")
            {
                result = c.Divide(value1, value2);
            }

            Console.WriteLine($"Resultado: {result}");

            Console.WriteLine("Pulse INTRO para finalizar...");
            Console.ReadLine();
        }
    }
}
using ElGuerre.Demos.CalculartorConsole;
using System;

namespace ElGuerre.Demos.CalculatorConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var options = new ArgumentsOptions();
            var isValid = CommandLine.Parser.Default.ParseArguments(args, options);
          
            if (isValid)
            {
                var c = new Calculator();
                double result = 0;
                switch (options.Operacion)
                {
                    case OperationType.suma:
                        result = c.Sum(options.Value1, options.Value2);
                        break;
                    case OperationType.divide:
                        result = c.Divide(options.Value1, options.Value2);
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"Resultado: {result}");
                // Console.WriteLine("Resultado: {0}", result);

                // Excepción: InvalidOperationException
                Console.WriteLine( );
                c.Divide(1, 5);
                Console.WriteLine();

                Console.WriteLine("Pulse INTRO para finalizar...");
                Console.ReadLine();
            }
        }
    }
}

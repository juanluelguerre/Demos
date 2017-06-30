using System;
using System.IO;

namespace DnaGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string strJson = File.ReadAllText("Model.json");

            var gen = new Generator(strJson,"");
            gen.Run();

            Console.WriteLine("Pulse INTRO para finalizar");
            Console.ReadLine();
        }
    }
}
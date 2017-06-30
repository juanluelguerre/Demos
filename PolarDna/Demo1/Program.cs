
    using System;
    namespace POLAR.Dna.Demo1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                    Owner o = new Owner();

                    Console.WriteLine("Owner Info:");
                    Console.WriteLine($"Nombre: {o.Name}");
                    Console.WriteLine($"Apellidos: {o.SurName}");
                    Console.WriteLine($"Direccion: {o.Address}");
                    Console.WriteLine($"Fecha nacimiento: {o.BirthDate}");

                    Console.WriteLine("Pulse Intro para finalizar...");
                    Console.ReadLine();
                }
        }
    }


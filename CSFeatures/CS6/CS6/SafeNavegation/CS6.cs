using System.Collections.Generic;
using static System.Console;

namespace FeaturesCS6
{
    class CS6
    {
        static void Main(string[] args)
        {
            Project p = new Project()
            {
                Id = 1,
                Title = "Project 1",
                Description = "New Features C#6",
                Tasks = new List<string>() { "Task 1" }
            };

            WriteLine($"El Proyecto '{p?.Title}' tiene {p?.Tasks?.Count ?? 0} tarea(s).");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}

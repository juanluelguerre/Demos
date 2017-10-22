using System.Collections.Generic;
using static System.Console;

namespace FeaturesCS6
{
    public class ProjectCS6
    {
        public int Id { get; } = 1;
        public string Title { get; set; } = "Project 1";
        public string Description { get; set; } = "New Features C#6";
        public Dictionary<string, string> Tasks { get; set; }
    }

    public class CS6
    {
        static void Main(string[] args)
        {
            WriteLine("Collections Initilizer:");

            var p = new ProjectCS6
            {
                Tasks = new Dictionary<string, string>()
                {
                    ["uno"] = "Task 1",
                    ["dos"] = "Task 2"
                }
            };
            //p.Tasks[4] = "Task 4";

            foreach (var item in p.Tasks)
            {
                WriteLine($"{item.Key}-{item.Value}");
            }


            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}


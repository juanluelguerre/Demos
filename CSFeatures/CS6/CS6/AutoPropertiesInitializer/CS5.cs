using System.Collections.Generic;

namespace FeaturesCS6
{


    public class ProjectCS5
    {
        public ProjectCS5()
        {
            Id = 1;
            Title = "Project 1";
            Description = "New Features C#6";
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CS5
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Auto Properties Initializer:");

            var p = new ProjectCS5();
            System.Console.WriteLine("Id: {0} - Title: {1}", p.Id, p.Title);

            System.Console.WriteLine("Pulse INTRO para finalizar...");
            System.Console.ReadLine();
        }
    }
}

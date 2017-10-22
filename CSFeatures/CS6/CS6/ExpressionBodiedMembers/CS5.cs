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
        public string GetDetail()
        {

            return string.Format(
                "This is a project with id {0}, title {1} and a description: {2}",
                Id, Title, Description);
        }
    }

    public class CS5
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Expression Bodied Members:");

            var p = new ProjectCS5();
            System.Console.WriteLine(p.GetDetail());

            System.Console.WriteLine("Pulse INTRO para finalizar...");
            System.Console.ReadLine();
        }
    }
}

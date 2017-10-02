using static System.Console;

namespace FeaturesCS6
{
    class CS5
    {
        static void Main(string[] args)
        {
            Project p = new Project()
            {
                Id = 1,
                Title = "Project 1",
                Description = "New Features C#6"
            };

            WriteLine("Id: {0} - Title: {1}", p.Id, p.Title);
            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}

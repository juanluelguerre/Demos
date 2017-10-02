using static System.Console;

namespace FeaturesCS6
{
    class CS5
    {
        static void Main(string[] args)
        {
            //C#5 - Initialization
            Project p = new Project()
            {
                Id = 1,
                Title = "Project 1",
                Description = "New Features CS6"
            };

            WriteLine("ID: {0} - Titulo:{1}", p.Id, p.Title);
            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}

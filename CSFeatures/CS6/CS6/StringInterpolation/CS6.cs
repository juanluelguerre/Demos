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
                Description = "New Features C#6"
            };

            // WriteLine("{0}: {1} - {2}: {3}", nameof(p.Id), p.Id, nameof(p.Title), p.Title);

            WriteLine($"Id: {p.Id} - Title: {p.Title}");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}

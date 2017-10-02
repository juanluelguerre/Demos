using static System.Console;

namespace FeaturesCS6
{
    class Program
    {
        static void Main(string[] args)
        {
            Project p = new Project();

            WriteLine("ID: {0} - Titulo:{1}", p.Id, p.Title);
            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}

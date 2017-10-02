using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            System.Console.WriteLine("{0}: {1} - {2}: {3}", nameof(p.Id), p.Id, nameof(p.Title), p.Title);
            System.Console.WriteLine("Pulse INTRO para finalizar...");
            System.Console.ReadLine();
        }
    }
}

//using System.Collections.Generic;
//using static System.Console;

//namespace FeaturesCS6
//{
//    public class ProjectCS6
//    {
//        public int Id { get; } = 1;
//        public string Title { get; set; } = "Project 1";
//        public string Description { get; set; } = "New Features C#6";
//        public Dictionary<int, string> Tasks { get; set; }
//    }

//    public class CS6
//    {
//        static void Main(string[] args)
//        {
//            WriteLine("Collections Initilizer:");

//            var p = new ProjectCS6();
//            p.Tasks = new Dictionary<int, string>()
//            {
//                [1] = "Task 1",
//                [2] = "Task 2",
//                [3] = "Task 3",
//                [3] = "Task 3.1"
//            };
//            p.Tasks[4] = "Task 4";

//            foreach (var item in p.Tasks)
//            {
//                WriteLine($"{item.Key}-{item.Value}");
//            }


//            WriteLine("Pulse INTRO para finalizar...");
//            ReadLine();
//        }
//    }
//}


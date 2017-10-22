//using System.Collections.Generic;

//namespace FeaturesCS6
//{


//    public class ProjectCS5
//    {
//        public ProjectCS5()
//        {
//            Id = 1;
//            Title = "Project 1";
//            Description = "New Features C#6";
//        }

//        public int Id { get; private set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public Dictionary<int, string> Tasks { get; set; }
//    }

//    public class CS5
//    {
//        static void Main(string[] args)
//        {
//            System.Console.WriteLine("Collectionns Initilizer:");

//            var p = new ProjectCS5
//            {
//                Tasks = new Dictionary<int, string>()
//                {
//                    {1, "Task 1"},
//                    {2, "Task 2"},
//                    {3, "Task 3"},
//                    {3, "Task 3.1"}
//                }
//            };
//            p.Tasks[4] = "Task 4";
//            foreach (var item in p.Tasks)
//            {
//                System.Console.WriteLine("{0}-{1}", item.Key, item.Value);
//            }

//            System.Console.WriteLine("Pulse INTRO para finalizar...");
//            System.Console.ReadLine();
//        }
//    }
//}

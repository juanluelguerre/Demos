using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Console;
namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            WriteLine("{0} : {1}", nameof(Employee.Id), emp.Id);
            WriteLine("{0} : {1}", nameof(Employee.Name), emp.Name);
            WriteLine("{0} : {1}", nameof(Employee.Salary), emp.Salary);
            ReadLine();
        }
    }
    class Employee
    {
        public int Id { get; set; } = 101;
        public string Name { get; set; } = "Nitin";
        public int Salary { get; set; } = 9999;
    }
}

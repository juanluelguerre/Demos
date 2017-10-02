using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Console;
namespace project7
{
    class Program
    {
       static void Main()
        {
            Employee emp = new Employee();
            emp.Name = "Nitin Pandit";
            emp.EmployeeAddress = new Address()
            {
                HomeAddress = "Noida Sec 15",
                OfficeAddress = "Noida Sec 16"
            };
            WriteLine((emp?.Name) + "  " + (emp?.EmployeeAddress?.HomeAddress??"No Address"));
            ReadLine();
        }
    }
    class Employee
    {
        public string Name { get; set; }
        public Address EmployeeAddress { get; set; }
    }
    class Address
    {
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }
    }
}

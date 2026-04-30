using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Console.Write("Employee ID : ");
            emp.EmpId = int.Parse(Console.ReadLine());

            Console.Write("Employee Name : ");
            emp.EmpName = Console.ReadLine();

            Console.Write("Employee Salary : ");
            emp.EmpSal = int.Parse(Console.ReadLine());

            BusinessLogic bl = new BusinessLogic();
            if (bl.AddEmployee(emp))
            {
                Console.WriteLine("Record Inserted Successfully.....");
            }
            else
            {
                Console.WriteLine("Record Insertion Failed");
            }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkEmployeeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table_Employee employee;
            BusinessLogic bl = new BusinessLogic();


        Menu:

            Console.Write("1.Add\n2.Delete\n3.Find\n4.GetAll\nEnter Your choice : ");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Employee ID :");
                    employee = new Table_Employee();
                    employee.eid = int.Parse(Console.ReadLine());
                    Console.Write("Enter Employee Name :");
                    employee.ename = Console.ReadLine();
                    Console.Write("Enter Employee Salary :");
                    employee.esal = int.Parse(Console.ReadLine());
                   
                    if (bl.AddEmployee(employee))
                    {
                        Console.WriteLine("Employee Added....");
                    }
                    else
                    {
                        Console.WriteLine("Employee Insertion Failed");
                    }
                 goto Menu;
                case 2:
                    Console.Write("Enter Employee ID :");
                    employee = new Table_Employee();
                    employee.eid = int.Parse(Console.ReadLine());
                   
                    
                    if (bl.DeleteEmployee(employee))
                    {
                        Console.WriteLine("Employee Deleted....");
                    }
                    else
                    {
                        Console.WriteLine("Employee Deletion Failed");
                    }
                    goto Menu;
                case 3:
                    Console.Write("Enter Employee  ID  : ");
                    employee = new Table_Employee();
                    employee.eid = int.Parse(Console.ReadLine());
                    employee = bl.FindEmployeeById(employee);
                    if (employee == null)
                    {
                        Console.WriteLine("Employee Not Found");
                    }
                    else
                    {

                        Console.WriteLine($"Employee Name :{employee.ename}");
                        Console.WriteLine($"Employee Salary :{employee.esal}");
                    }

                    goto Menu;
                case 4:
                    if (bl.Employees()!=null)
                    {
                        foreach (Table_Employee emp in bl.Employees())
                        {
                            Console.WriteLine($"{emp.eid}\t{emp.ename}\t{emp.esal}");
                        }
                    }
                    else
                    {

                        Console.WriteLine("Employees Not Found");
                    }
                    goto Menu;

                default:
                    Console.WriteLine("Invalid Choice .....");
                    goto Menu;





            }




        }
    }
}

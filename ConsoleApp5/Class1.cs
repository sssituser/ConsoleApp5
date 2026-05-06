using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp5
{
    internal class Class1
    {
        static void Main(string[] args)
        {

            Employee emp = new Employee();
            SecurityAccessLayer sl = new SecurityAccessLayer();



        Menu:
            Console.Write("1.Add\n2.Delete\n3.Edit\n4.Find\n5.FindAll\nEnter Your choice : ");
            int option = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (option)
            {
                case 1:
                    Console.Write("Employee ID : ");
                    emp.EmpId = int.Parse(Console.ReadLine());

                    Console.Write("Employee Name : ");
                    emp.EmpName = Console.ReadLine();

                    Console.Write("Employee Salary : ");
                    emp.EmpSal = int.Parse(Console.ReadLine());

                    if (sl.AddEmployee(emp))
                    {
                        Console.WriteLine("Record Inserted Successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Record Insertion Failed");
                    }

                    goto Menu;
                case 2:
                    Console.Write("Enter Employee ID  :");
                    emp.EmpId = int.Parse(Console.ReadLine());
                    if (sl.DeleteEmployee(emp))
                    {
                        Console.WriteLine("Record Deleted Successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Record Deletion Failed");
                    }
                    goto Menu;
                case 3:
                    Console.Write("Employee ID : ");
                    emp.EmpId = int.Parse(Console.ReadLine());

                    Console.Write("Employee Name : ");
                    emp.EmpName = Console.ReadLine();

                    Console.Write("Employee Salary : ");
                    emp.EmpSal = int.Parse(Console.ReadLine());

                    if (sl.UpdateEmployee(emp))
                    {
                        Console.WriteLine("Record Updated Successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Record Update Failed");
                    }

                    goto Menu;
                case 4:
                    Console.Write("Enter Employee ID : ");
                    emp.EmpId = int.Parse(Console.ReadLine());
                    if (sl.FindEmployeeById(emp) == null)
                    {
                        Console.WriteLine("Record Not Found");
                        goto Menu;
                    }
                    emp = sl.FindEmployeeById(emp);
                    Console.WriteLine($"Employee Name :{emp.EmpName}");
                    Console.WriteLine($"Employee Salary :{emp.EmpSal}");
                    goto Menu;
                case 5:
                    if (sl.FindAll() != null)
                    {
                        List<Employee> emplist = sl.FindAll();
                        foreach (Employee empp in emplist)
                        {
                            Console.WriteLine(empp);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Records Not Available");
                    }
                    goto Menu;
                default:
                    Console.WriteLine("Invalid choice : ");
                    goto Menu;
            }


        }
    }
}



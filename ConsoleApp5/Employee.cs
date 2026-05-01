using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSal { get; set; }

        public override string ToString()
        {
            return "Employee ID : " + EmpId + "\tEmployee Name : " + EmpName + "\tEmployee Salary : " + EmpSal;
        }
    }
}

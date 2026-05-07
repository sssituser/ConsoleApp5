using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkEmployeeConsoleApp
{
    internal class BusinessLogic
    {
        ProjectDBEntities Db;
       
        public BusinessLogic()
        {
            Db = new ProjectDBEntities();
           
        }
        public bool AddEmployee(Table_Employee employee)
        {
            Db.Table_Employee.Add(employee);
            return Db.SaveChanges() == 1;
        }
        public bool DeleteEmployee(Table_Employee employee)
        {
            employee = Db.Table_Employee.Find(employee.eid);
            if (employee != null)
            {
                Db.Table_Employee.Remove(employee);
                return Db.SaveChanges() == 1;
            }
            return false;
        }
        public Table_Employee FindEmployeeById(Table_Employee employee)
        {
            employee = Db.Table_Employee.Find(employee.eid);
            if (employee != null)
            {
                return employee;
            }
            return null;

        }
        public List<Table_Employee> Employees()
        {
            return Db.Table_Employee.ToList();
        }

    }
}


using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ConsoleApp5
{    // Connected Architecture Business Logic
    // Business Logic is responsible for performing all the database related operations like insert, update, delete and select
    internal class BusinessLogic
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dataReader;
        public BusinessLogic()
        {
            connection = new SqlConnection("Data Source=LAPTOP-273GI8F1\\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True;Encrypt=False");
            command = new SqlCommand();
            command.Connection=connection;
            connection.Close();
        }
        public bool AddEmployee(Employee emp)
        {
            command.CommandText = $"insert into tbl_employee values({emp.EmpId},'{emp.EmpName}',{emp.EmpSal})";
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res == 1;

        }
        public bool DeleteEmployee(Employee emp)
        {
            command.CommandText = $"delete from tbl_employee where eid = {emp.EmpId}";
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res == 1;

        }
        public bool UpdateEmployee(Employee emp)
        {
            command.CommandText = $"update tbl_employee set ename ='{emp.EmpName}',esal ={emp.EmpSal} where eid ={emp.EmpId}";
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res == 1;

        }
        public Employee FindEmployeeById(Employee emp)
        {
            command.CommandText = $"select * from tbl_employee where eid ={emp.EmpId}";
            connection.Open();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                emp.EmpName =dataReader["ename"].ToString();
                emp.EmpSal = int.Parse(dataReader["esal"].ToString());
            }
            else
            {

                emp = null;
            }
            connection.Close();
            return emp;

        }
        public List<Employee> FindAll()
        {
            List<Employee> employees = new List<Employee>();
            command.CommandText = "select * from tbl_employee";
            connection.Open();
            dataReader=command.ExecuteReader();
            while (dataReader.Read())
            {
                Employee emp = new Employee();
                emp.EmpId = dataReader.GetInt32(0);
                emp.EmpName = dataReader.GetString(1);
                emp.EmpSal = dataReader.GetInt32(2);
                employees.Add(emp);
            }
            connection.Close();
            return employees;
        }

    }
}

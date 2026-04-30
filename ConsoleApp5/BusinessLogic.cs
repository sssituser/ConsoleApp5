
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp5
{
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
            command.CommandText = $"delete from tbl_employee where eid = {emp.EmpId})";
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

    }
}

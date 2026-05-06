using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ConsoleApp5
{
    
    internal class SecurityAccessLayer
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cmb;
        DataSet ds;
        DataRow row;
        public SecurityAccessLayer()
        {
            con = new SqlConnection("Data Source=LAPTOP-273GI8F1\\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True;Encrypt=False");
            da = new SqlDataAdapter("select * from tbl_employee",con);
            cmb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "tbl_employee");
            ds.Tables["tbl_employee"].Constraints.Add("pk_eid", ds.Tables["tbl_employee"].Columns["eid"], true);
            
        }
        public bool AddEmployee(Employee emp)
        {
            row = ds.Tables["tbl_employee"].NewRow();
            row["eid"] = emp.EmpId;
            row["ename"] = emp.EmpName;
            row["esal"] = emp.EmpSal;
            ds.Tables["tbl_employee"].Rows.Add(row);
            int res =  da.Update(ds, "tbl_employee");
            return res == 1;

        }
        public bool DeleteEmployee(Employee emp)
        {
            ds.Tables["tbl_employee"].Rows.Find(emp.EmpId).Delete();
            int res = da.Update(ds, "tbl_employee");
            return res == 1;
        }
        public Employee FindEmployeeById(Employee emp)
        {
            row = ds.Tables["tbl_employee"].Rows.Find(emp.EmpId);
            if (row != null)
            {
                emp.EmpName = row["ename"].ToString();
                emp.EmpSal = int.Parse(row["esal"].ToString());
                return emp;
            }
            return null;
        }
        public bool UpdateEmployee(Employee emp)
        {
            row = ds.Tables["tbl_employee"].Rows.Find(emp.EmpId);
            if(row != null)
            {
                row["ename"] = emp.EmpName;
                row["esal"] = emp.EmpSal;
                int res = da.Update(ds, "tbl_employee");
                return res == 1;
            }
            return false;
        }
        public List<Employee> FindAll()
        {
            List<Employee> emplist = new List<Employee>();
            foreach(DataRow row1 in ds.Tables["tbl_employee"].Rows)
            {
                Employee emp = new Employee();
                emp.EmpId = int.Parse(row1["eid"].ToString());
                emp.EmpName = row1["ename"].ToString();
                emp.EmpSal = int.Parse(row1["esal"].ToString()) ;
                emplist.Add(emp);

            }
            return emplist;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Services
{
    public class EmployeeDAL : IService<Employee>
    {
        private DBConnection Connection;
        public EmployeeDAL()
        {
            Connection = new DBConnection();
        }
        public void Create(Employee item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Employees WHERE Id = @Id; ";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt16(id);
            Connection.ExecuteDeleteQuery(query, sqlParameters);
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            string query = string.Format(@"SELECT        dbo.Employees.Name, dbo.Employees.Surname, dbo.Employees.Middlename, dbo.Employees.EmploymentDate, dbo.Employees.Position, dbo.Companies.Name AS CompanyName, dbo.Companies.Id
                                           FROM            dbo.Employees INNER JOIN
                                           dbo.Companies ON dbo.Employees.CompanyId = dbo.Companies.Id");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<Employee> Employees = new List<Employee>();
            DataTable data = Connection.ExecuteSelectQuery(query, sqlParameters);
            foreach (DataRow dr in data.Rows)
            {
                Employee employee = new Employee();
                employee.Id = Int32.Parse(dr["Id"].ToString());
                employee.Name = dr["Name"].ToString();
                employee.Surname = dr["Surname"].ToString();
                employee.Middlename = dr["Middlename"].ToString();
                employee.EmploymentDate = DateTime.Parse(dr["EmploymentDate"].ToString());
                employee.Position = dr["Position"].ToString();
                employee.Company = dr["CompanyName"].ToString();
                Employees.Add(employee);
            }

            return Employees;
        }

        public void Update(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}

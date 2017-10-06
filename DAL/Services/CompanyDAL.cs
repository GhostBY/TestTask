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
    public class CompanyDAL:IService<Company>
    {
        private DBConnection Connection;
        public CompanyDAL()
        {
            Connection = new DBConnection();
        }
         public List<Company> GetAll()
        {
            string query = string.Format("select * from [Companies]"); 
            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<Company> Companies = new List<Company>();
            DataTable data= Connection.ExecuteSelectQuery(query, sqlParameters);
            foreach (DataRow dr in data.Rows)
            {
                Company company = new Company();
                company.Id = Int32.Parse(dr["Id"].ToString());
                company.Size = Int32.Parse(dr["Size"].ToString());
                company.Name = dr["Name"].ToString();
                company.OrganizationalForm = dr["OrganizationalForm"].ToString();
                Companies.Add(company);
            }
            
            return Companies;
        }

        public Company Get(int id)
        {
            string query = "select * from [Companies] where Id = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(id);
            DataTable data = Connection.ExecuteSelectQuery(query, sqlParameters);
            Company company = new Company();
            foreach (DataRow dr in data.Rows)
            {
                company.Id = Int32.Parse(dr["Id"].ToString());
                company.Size = Int32.Parse(dr["Size"].ToString());
                company.Name = dr["Name"].ToString();
                company.OrganizationalForm = dr["OrganizationalForm"].ToString();
            }
            return company;
        }

        public void Create(Company item)
        {
            throw new NotImplementedException();
        }

        public void Update(Company item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

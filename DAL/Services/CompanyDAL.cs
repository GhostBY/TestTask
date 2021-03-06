﻿using System;
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
            string query = "INSERT INTO Companies (Name, Size, OrganizationalForm) VALUES(@Name, @Size, @OrganizationalForm); ";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(item.Name);
            sqlParameters[1] = new SqlParameter("@Size", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToInt16(item.Size);
            sqlParameters[2] = new SqlParameter("@OrganizationalForm", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(item.OrganizationalForm);
            Connection.ExecuteInsertQuery(query, sqlParameters);
        }

        public void Update(Company item)
        {
            string query = "UPDATE Companies SET Name = @Name, Size = @Size, OrganizationalForm = @OrganizationalForm WHERE Id = @Id; ";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt16(item.Id);
            sqlParameters[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(item.Name);
            sqlParameters[2] = new SqlParameter("@Size", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt16(item.Size);
            sqlParameters[3] = new SqlParameter("@OrganizationalForm", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(item.OrganizationalForm);
            Connection.ExecuteUpdateQuery(query, sqlParameters);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Companies WHERE Id = @Id; ";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt16(id);
            Connection.ExecuteDeleteQuery(query, sqlParameters);
        }
    }
}

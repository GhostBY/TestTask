using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
    public  class DBConnection
    {
        private  SqlConnection Connection = null;
        private  SqlDataAdapter Adapter = null;

        public DBConnection()
        {
            Adapter = new SqlDataAdapter();
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings
                    ["LocalConnection"].ConnectionString);
        }
        private SqlConnection OpenConnection()
        {
            if(Connection.State==ConnectionState.Closed||Connection.State==ConnectionState.Broken)
            {
                Connection.Open();
            }
            return Connection;
        }
        public DataTable ExecuteSelectQuery(string Query, SqlParameter[] Parameters)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = Query;
                myCommand.Parameters.AddRange(Parameters);
                myCommand.ExecuteNonQuery();
                Adapter.SelectCommand = myCommand;
                Adapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {
            }
            return dataTable;
        }

        public bool ExecuteInsertQuery(string Query, SqlParameter [] Parameters)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = Query;
                myCommand.Parameters.AddRange(Parameters);
                Adapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }

        public bool ExecuteUpdateQuery(string Query, SqlParameter[] Parameters)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = Query;
                myCommand.Parameters.AddRange(Parameters);
                Adapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }
        public bool ExecuteDeleteQuery(string Query, SqlParameter[] Parameters)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = Query;
                myCommand.Parameters.AddRange(Parameters);
                Adapter.DeleteCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }
    }
}

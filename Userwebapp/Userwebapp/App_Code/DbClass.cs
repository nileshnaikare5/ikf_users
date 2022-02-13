using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Userwebapp
{
    public class DbClass
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private SqlDataAdapter datadptr;
        public DataSet ds;
        

        // Function to get connection.
        public void DatabaseConnection()
        {
                       
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        }

        // Function to open connection to DB.
        public SqlConnection Openconn()
        {
            DatabaseConnection();
            if (connect.State == ConnectionState.Closed || connect.State == ConnectionState.Broken)
            {
                connect.Open();
            }
            return connect;
        }

        // Function to close connection to DB.
        public SqlConnection Closeconn()
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
            return connect;
        }

        // Function to Insert,Update & Deleting values in DB.
        public void ExecuteQuery(string SProcName, SqlCommand cmd)
        {
            try
            {
                cmd.Connection = Openconn();
                cmd.CommandText = SProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                Closeconn();
            }

        }

        // Function to return values using Dataset.
        public DataSet returnDataSet(string SProcName, SqlCommand cmd)
        {
            try
            {
                cmd.Connection = Openconn();
                cmd.CommandText = SProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                datadptr = new SqlDataAdapter(cmd);
                ds = new DataSet();
                datadptr.Fill(ds);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Closeconn();
            }
            return (ds);
        }

        // Function to return values using Data-Table.
        public DataTable returnDataTable(string SProcName, SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = Openconn();
                cmd.CommandText = SProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                datadptr = new SqlDataAdapter(cmd);
                datadptr.Fill(dt);
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                Closeconn();
            }
            return dt;
        }

        // Function to return  string values using Execute Scalar.
        public string returnString(string SProcName, SqlCommand cmd)
        {
            string returnValue = "";
            try
            {
                cmd.Connection = Openconn();
                cmd.CommandText = SProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                returnValue = (string)cmd.ExecuteScalar();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                Closeconn();
            }
            return (returnValue);
        }

        // Function to return  integer values using Execute Scalar.
        public int returnInteger(string SProcName, SqlCommand cmd)
        {
            int returnValue = 0;
            try
            {
                cmd.Connection = Openconn();
                cmd.CommandText = SProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                returnValue = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                Closeconn();
            }
            return (returnValue);
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

namespace Userwebapp
{
    public class DAL
    {
        DbClass dbClass = new DbClass();
        SqlCommand sqlcmd;
        public DataTable GetUsers()
        {
            DataTable dtUsers = new DataTable();
            sqlcmd = new SqlCommand();
            dtUsers = dbClass.returnDataTable("usp_GetUsers", sqlcmd);
            return dtUsers;

        }

        public int AUD_User(int UserID,string Name, string DOB, string Designation, string Skills, string AUFlag)
        {
            int iUserID = 0;
            try
            {
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserID;
                sqlcmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                sqlcmd.Parameters.Add("@DOB", SqlDbType.VarChar).Value = DOB;
                sqlcmd.Parameters.Add("@Designation", SqlDbType.VarChar).Value = Designation;
                sqlcmd.Parameters.Add("@Skills", SqlDbType.VarChar).Value = Skills;
                sqlcmd.Parameters.Add("@AuFlag", SqlDbType.Char).Value = AUFlag;
                iUserID = dbClass.returnInteger("usp_Users", sqlcmd);
            }
            catch (Exception ex) { }
            return iUserID;
        }
    }
}
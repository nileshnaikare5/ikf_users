
using System.Data;


namespace Userwebapp
{
    public class BAL
    {
        DAL dal = new DAL();

        public BAL()
        { 
        
        }

        public DataTable GetUsers()
        {
            return dal.GetUsers();
        }

        public int AUD_User(int UserID, string Name, string DOB, string Designation, string Skills, string AUFlag)
        {
            return dal.AUD_User(UserID, Name, DOB, Designation, Skills, AUFlag);
        }

    }
}
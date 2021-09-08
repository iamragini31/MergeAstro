using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace Pandit_ApplicationManager
{
   public class CallCustomerManager
    {


        public int Deductedamount(double amount, double custid,double Bookingid)
        {
            SqlParameter p1 = new SqlParameter("@Custid",custid);
            SqlParameter p2 = new SqlParameter("@Transactionamt", amount);
            SqlParameter p3 = new SqlParameter("@Bookingid", Bookingid);
            SqlParameter flag = new SqlParameter("@Flag", '3');

            int res = 0;
            try
            {
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Pandit_Chat_CallHistory", p1, p2, flag,p3);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return res;
        }
    }
}

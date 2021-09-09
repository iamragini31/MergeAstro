using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using Pandit_ApplicationEntity;

namespace Pandit_ApplicationManager
{
  public  class DefaultManager
    {

        public int saveCustomer(string Fullname,string password,string email)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@Fullname",Fullname);
            SqlParameter p2 = new SqlParameter("@Password", password);
            SqlParameter p3 = new SqlParameter("@Email", email);
            SqlParameter flag = new SqlParameter("@Flag", '1');
            try
            {
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_CustomerMaster", p1, p2, p3, flag);
            }
            catch(Exception ex)
            {

            }
            return res;

        }

        public DefaultModel Validateuser(string username,string password)
        {
            DefaultModel model = new DefaultModel();
            SqlParameter p2 = new SqlParameter("@Password", password);
            SqlParameter p3 = new SqlParameter("@Email", username);
            SqlParameter flag = new SqlParameter("@Flag", '2');

            DataTable dt = new DataTable();
            try
            {
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_CustomerMaster", p2, p3, flag);
                if(dt.Rows.Count >0 && dt != null)
                {
                    model.CustomerID= Convert.ToInt32(dt.Rows[0]["Id"]);
                    model.email = dt.Rows[0]["Email"].ToString();
                    model.password = dt.Rows[0]["Password"].ToString();
                    model.FullName = dt.Rows[0]["Fullname"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        public double GetWalletamount(long custid)
        {
            double res = 0;
            SqlParameter p1 = new SqlParameter("@Custid",custid);
            SqlParameter flg = new SqlParameter("@Flag", '3');
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_WalletTransactionMaster", p1, flg);
            if (dt.Rows.Count > 0 && dt!=null)
            {
                res = Convert.ToInt32(dt.Rows[0]["Walletamt"]);
            }
            return res;
        }
        public int saveCustomerGmail(string Fullname,  string email)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@Fullname", Fullname);
           
            SqlParameter p3 = new SqlParameter("@Email", email);
            SqlParameter flag = new SqlParameter("@Flag", '4');
            try
            {
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_CustomerMaster", p1, p3, flag);
            }
            catch (Exception ex)
            {

            }
            return res;

        }
        public DefaultModel Validateusergmail(string username)
        {
            DefaultModel model = new DefaultModel();
            
            SqlParameter p3 = new SqlParameter("@Email", username);
            SqlParameter flag = new SqlParameter("@Flag", '5');

            DataTable dt = new DataTable();
            try
            {
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_CustomerMaster", p3, flag);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    model.CustomerID = Convert.ToInt32(dt.Rows[0]["Id"]);
                    model.email = dt.Rows[0]["Email"].ToString();
                    
                    model.FullName = dt.Rows[0]["Fullname"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }


        public int DeleteAccount(string custid)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@CustId", custid);
            SqlParameter flg = new SqlParameter("@Flag", '8');
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_CustomerMaster", p1, flg);

            return res;
        }
    }
}

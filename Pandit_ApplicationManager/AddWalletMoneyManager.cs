using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using Pandit_ApplicationEntity;
namespace Pandit_ApplicationManager
{
  public  class AddWalletMoneyManager
    {


        public int SaveTransaction(string PaymentID,long amount,long custid,string Orderid)
        {
            SqlParameter p1 = new SqlParameter("@Amount",amount);
            SqlParameter p2 = new SqlParameter("@Custid",custid);
            SqlParameter p3 = new SqlParameter("@TransactionID",PaymentID);
            SqlParameter p4 = new SqlParameter("@Orderid",Orderid);
            SqlParameter p5 = new SqlParameter("@Flag",'1');
            int res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Transactionmaster", p1, p2, p3, p4, p5);
            return res;
        }


        public SelectedPujaModel GetServicesAmount(string Servicename, int panditID)
        {
            int res = 0;
           
            SqlParameter p2 = new SqlParameter("@Servicename", Servicename);
            SqlParameter p3 = new SqlParameter("@PanditID", panditID);
            SqlParameter p4 = new SqlParameter("@Flag", '2');
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_WalletTransactionMaster", p2, p3, p4);
            SelectedPujaModel model = new SelectedPujaModel();
            if (dt.Rows.Count > 0 && dt != null)
            {
                model.amount = Convert.ToInt32(dt.Rows[0]["Price"]);
             
            }
            return model;

        }
    }
}

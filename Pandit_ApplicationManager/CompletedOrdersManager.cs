using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandit_ApplicationEntity;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace Pandit_ApplicationManager
{
    public class CompletedOrdersManager
    {

        public List<OrdersModel> BindService(string panditid)
        {
            List<OrdersModel> list = new List<OrdersModel>();
            SqlParameter flag = new SqlParameter("@Flag", '6');
            SqlParameter p1 = new SqlParameter("@PanditID", panditid);
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditOrderHistory", flag, p1);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        OrdersModel model = new OrdersModel();
                        model.OrderID = dt.Rows[i]["OrderID"].ToString();
                        model.Custname = dt.Rows[i]["Name"].ToString();
                        model.ReceivedDate = dt.Rows[i]["Received_Date"].ToString();
                        model.Servicename = dt.Rows[i]["Service"].ToString();
                        model.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        model.Receivedtime = dt.Rows[i]["ReceiveTime"].ToString();
                        //model.Service_Time= dt.Rows[i][""].ToString();
                        //model.Status = dt.Rows[i]["Status"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }
    }
}

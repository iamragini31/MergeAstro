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
   public class ChatOrdersManager
    {
        public List<ChatOrdersModel> BindChat(string PanditID)
        {
            List<ChatOrdersModel> list = new List<ChatOrdersModel>();
            SqlParameter flag = new SqlParameter("@Flag", '1');
            SqlParameter p1 = new SqlParameter("@PanditID", PanditID);
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Pandit_Chat_CallHistory", flag, p1);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ChatOrdersModel model = new ChatOrdersModel();
                        model.orderid = dt.Rows[i]["OrderID"].ToString();
                        model.FirstName_Call = dt.Rows[i]["FirstName_Call"].ToString();
                        model.Gender = dt.Rows[i]["Gender"].ToString();
                        model.DOB = dt.Rows[i]["DOB"].ToString();
                        model.Time_of_Birth = dt.Rows[i]["Time_of_Birth"].ToString();
                        model.City = dt.Rows[i]["City"].ToString();
                        model.State = dt.Rows[i]["State"].ToString();
                        model.Country = dt.Rows[i]["Country"].ToString();
                        model.Martial_Status = dt.Rows[i]["Martial_Status"].ToString();
                        model.Topicforcall = dt.Rows[i]["Topicforcall"].ToString();
                        model.Language = dt.Rows[i]["Language"].ToString();
                        model.Received_Date = dt.Rows[i]["Received_Date"].ToString();
                        //model.Service = dt.Rows[i]["Service"].ToString();
                        model.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        model.CustID = Convert.ToInt32(dt.Rows[i]["Custid"]);

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

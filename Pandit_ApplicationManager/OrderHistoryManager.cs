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
   public class OrderHistoryManager
    {

        public List<OrderHistoryModel> BindService(string custid,string service)
        {
            List<OrderHistoryModel> list = new List<OrderHistoryModel>();
            SqlParameter flag = new SqlParameter("@Flag",'4');
            SqlParameter p1 = new SqlParameter("@custid", custid);
            SqlParameter p3 = new SqlParameter("@service", service);
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_Details", flag,p1,p3);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        OrderHistoryModel model = new OrderHistoryModel();
                        model.Orderid= dt.Rows[i]["OrderID"].ToString();
                        model.Customername = dt.Rows[i]["Name"].ToString();
                        model.Received_Date = dt.Rows[i]["Received_Date"].ToString();
                        model.Servicename = dt.Rows[i]["Servicename"].ToString();
                        model.Serviceprice = dt.Rows[i]["Price"].ToString();
                        //model.Service_Time= dt.Rows[i][""].ToString();
                        model.Status = dt.Rows[i]["Status"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return list;
        }

        public List<OrderHistoryModel> BindPuja(string custid, string service)
        {
            List<OrderHistoryModel> list = new List<OrderHistoryModel>();
            SqlParameter flag = new SqlParameter("@Flag", '1');
            SqlParameter p1 = new SqlParameter("@custid", custid);
            SqlParameter p3 = new SqlParameter("@service", service);
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_Details", flag, p1, p3);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        OrderHistoryModel model = new OrderHistoryModel();
                        model.Orderid = dt.Rows[i]["OrderID"].ToString();
                        model.Customername = dt.Rows[i]["Name"].ToString();
                        model.Received_Date = dt.Rows[i]["Received_Date"].ToString();
                        model.Servicename = dt.Rows[i]["Servicename"].ToString();
                        model.Serviceprice = dt.Rows[i]["Price"].ToString();
                        //model.Service_Time= dt.Rows[i][""].ToString();
                        model.Status = dt.Rows[i]["Status"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public List<OrderHistoryModel> BindCallservice(string custid)
        {
            List<OrderHistoryModel> list = new List<OrderHistoryModel>();
            SqlParameter flag = new SqlParameter("@Flag", '2');
            SqlParameter p1 = new SqlParameter("@custid", custid);
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_Details", flag, p1);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string duration = string.Empty;
                        OrderHistoryModel model = new OrderHistoryModel();
                        model.Orderid = dt.Rows[i]["OrderID"].ToString();
                        model.panditName = dt.Rows[i]["FullName"].ToString();
                        model.Received_Date = dt.Rows[i]["Received_Date"].ToString();
                        model.Callrate = Convert.ToDouble(dt.Rows[i]["CallRate"].ToString());
                        duration = dt.Rows[i]["Duration"].ToString();
                        duration = duration.Replace("mins", "");
                        model.Duration = Convert.ToDouble(duration);
                       
                        model.Wallet = Convert.ToDouble(dt.Rows[i]["Wallet Deduction"].ToString());
                        model.Status = dt.Rows[i]["Status"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public List<OrderHistoryModel> BindChatservice(string custid)
        {
            List<OrderHistoryModel> list = new List<OrderHistoryModel>();
            SqlParameter flag = new SqlParameter("@Flag", '3');
            SqlParameter p1 = new SqlParameter("@custid", custid);
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_Details", flag, p1);
            try
            {
                string duration = string.Empty;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        OrderHistoryModel model = new OrderHistoryModel();
                        model.Orderid = dt.Rows[i]["OrderID"].ToString();
                        model.panditName = dt.Rows[i]["FullName"].ToString();
                        model.Received_Date = dt.Rows[i]["Received_Date"].ToString();
                        model.Callrate = Convert.ToDouble(dt.Rows[i]["CallRate"].ToString());
                        duration = dt.Rows[i]["Duration"].ToString();
                        duration = duration.Replace("mins", "");
                        model.Duration = Convert.ToDouble(duration);
                        model.Wallet = Convert.ToDouble(dt.Rows[i]["WalletDeduction"].ToString());
                        model.Status = dt.Rows[i]["Status"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public List<OrderHistoryModel> BindReport(string custid)
        {
            List<OrderHistoryModel> list = new List<OrderHistoryModel>();
            SqlParameter flag = new SqlParameter("@Flag", '3');
            SqlParameter p1 = new SqlParameter("@Custid", custid);
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Customer_DetailedReport", flag, p1);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        OrderHistoryModel model = new OrderHistoryModel();
                        model.Orderid = dt.Rows[i]["OrderID"].ToString();
                        model.Customername = dt.Rows[i]["FullName"].ToString();
                        model.Received_Date = dt.Rows[i]["ReceivedDate"].ToString();
                        model.Servicename = dt.Rows[i]["ReportName"].ToString();
                        model.Serviceprice = dt.Rows[i]["Price"].ToString();
                        //model.Service_Time= dt.Rows[i][""].ToString();
                        model.Status = dt.Rows[i]["Status"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public OrderHistoryModel Bindtab(long sessionUserId)
        {
            OrderHistoryModel model = new OrderHistoryModel();
            try
            {
                SqlParameter p1 = new SqlParameter("@PanditID", sessionUserId);
                SqlParameter flag = new SqlParameter("@Flag", "13");
                DataSet ds = new DataSet();
                ds = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_PanditOrderHistory", p1, flag);
                if (ds.Tables.Count > 0)
                {
                    model.Opencall = Convert.ToInt64(ds.Tables[0].Rows[0]["Opencall"]);
                    model.Openchat = Convert.ToInt64(ds.Tables[1].Rows[0]["OpenChat"]);
                    model.Openservice = Convert.ToInt64(ds.Tables[2].Rows[0]["Openorders"]);
                    
                    model.acceptedservice = Convert.ToInt64(ds.Tables[3].Rows[0]["Acceptedservices"]);
                    model.completedservice = Convert.ToInt64(ds.Tables[4].Rows[0]["Closedservices"]);
                    model.rejectedservice = Convert.ToInt64(ds.Tables[5].Rows[0]["Rejectedservices"]);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }


            return model;
        }
    }
}

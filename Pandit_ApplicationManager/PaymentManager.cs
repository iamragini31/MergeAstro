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
    public class PaymentManger
    {
        PaymentModel punditregformmodel = new PaymentModel();
        public List<PaymentModel> GetAllPandits()
        {
            List<PaymentModel> List = new List<PaymentModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "5");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PaymentModel paymentmodel = new PaymentModel();
                        paymentmodel.FullName = dt.Rows[i]["FullName"].ToString();
                        paymentmodel.PanditId = Convert.ToInt64(dt.Rows[i]["Id"]);
                        List.Add(paymentmodel);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }


        public List<PaymentModel> FetchPaidPaymentforservices(PaymentModel paymentmodel)
        {
            int res = 0;
            List<PaymentModel> list = new List<PaymentModel>();
            //string fromdate = ConvertMMDDYYYY(paymentmodel.FromDate);
            //string todate = ConvertMMDDYYYY(paymentmodel.ToDate);
            //SqlParameter p1 = new SqlParameter("@FromDate", fromdate);
            //SqlParameter p2 = new SqlParameter("@ToDate", todate);
            SqlParameter p1 = new SqlParameter("@FromDate", paymentmodel.FromDate);
            SqlParameter p2 = new SqlParameter("@ToDate", paymentmodel.ToDate);
            SqlParameter p3 = new SqlParameter("@PanditID", paymentmodel.PanditId1);


            SqlParameter flag = new SqlParameter("@Flag", "7");
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditOrderHistory", p1, p2, p3, flag);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PaymentModel model = new PaymentModel();
                    model.customername = (dt.Rows[i]["Name"]).ToString();
                    model.Servicename = dt.Rows[i]["Service"].ToString();
                    model.receiveddate = dt.Rows[i]["Received_Date"].ToString();
                    model.amount = Convert.ToInt64(dt.Rows[i]["Price"]);
                    model.Bookingid = Convert.ToInt64(dt.Rows[i]["ID"]);
                    list.Add(model);
                }


            }
            return list;
        }

        string ConvertMMDDYYYY(string dt)
        {
            string finaldt = string.Empty;
            string[] strdt = dt.Split('-');
            finaldt = strdt[1] + "/" + strdt[2] + "/" + strdt[0];
            return finaldt;
        }


        public List<PaymentModel> FetchunPaidPaymentforservices(PaymentModel paymentmodel)
        {
            int res = 0;
            List<PaymentModel> list = new List<PaymentModel>();
            //string fromdate = ConvertMMDDYYYY(paymentmodel.FromDate);
            //string todate = ConvertMMDDYYYY(paymentmodel.ToDate);
            //SqlParameter p1 = new SqlParameter("@FromDate", fromdate);
            //SqlParameter p2 = new SqlParameter("@ToDate", todate);
            SqlParameter p1 = new SqlParameter("@FromDate", paymentmodel.FromDate);
            SqlParameter p2 = new SqlParameter("@ToDate", paymentmodel.ToDate);
            SqlParameter p3 = new SqlParameter("@PanditID", paymentmodel.PanditId1);


            SqlParameter flag = new SqlParameter("@Flag", "8");
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditOrderHistory", p1, p2, p3, flag);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PaymentModel model = new PaymentModel();
                    model.customername = (dt.Rows[i]["Name"]).ToString();
                    model.Servicename = dt.Rows[i]["Service"].ToString();
                    model.receiveddate = dt.Rows[i]["Received_Date"].ToString();
                    model.amount = Convert.ToInt64(dt.Rows[i]["Price"]);
                    model.Bookingid = Convert.ToInt64(dt.Rows[i]["ID"]);
                    list.Add(model);
                }


            }
            return list;
        }


        public List<PaymentModel> FetchunPaidPaymentforchatcall(PaymentModel paymentmodel)
        {
            int res = 0;
            List<PaymentModel> list = new List<PaymentModel>();
            //string fromdate = ConvertMMDDYYYY(paymentmodel.FromDate);
            //string todate = ConvertMMDDYYYY(paymentmodel.ToDate);
            //SqlParameter p1 = new SqlParameter("@FromDate", fromdate);
            //SqlParameter p2 = new SqlParameter("@ToDate", todate);
            SqlParameter p1 = new SqlParameter("@FromDate", paymentmodel.FromDate);
            SqlParameter p2 = new SqlParameter("@ToDate", paymentmodel.ToDate);
            SqlParameter p3 = new SqlParameter("@PanditID", paymentmodel.PanditId1);


            SqlParameter flag = new SqlParameter("@Flag", "9");
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditOrderHistory", p1, p2, p3, flag);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PaymentModel model = new PaymentModel();
                    model.customername = (dt.Rows[i]["FirstName_Call"]).ToString();
                    model.Servicename = dt.Rows[i]["Specialization"].ToString();
                    model.receiveddate = dt.Rows[i]["Received_Date"].ToString();
                    model.amount = Convert.ToInt64(dt.Rows[i]["Price"]);
                    model.duration = dt.Rows[i]["Duration"].ToString();
                    model.Bookingid = Convert.ToInt64(dt.Rows[i]["ID"]);

                    list.Add(model);
                }


            }
            return list;
        }

        public List<PaymentModel> FetchPaidPaymentforchatcall(PaymentModel paymentmodel)
        {
            int res = 0;
            List<PaymentModel> list = new List<PaymentModel>();
            //string fromdate = ConvertMMDDYYYY(paymentmodel.FromDate);
            //string todate = ConvertMMDDYYYY(paymentmodel.ToDate);
            //SqlParameter p1 = new SqlParameter("@FromDate", fromdate);
            //SqlParameter p2 = new SqlParameter("@ToDate", todate);
            SqlParameter p1 = new SqlParameter("@FromDate", paymentmodel.FromDate);
            SqlParameter p2 = new SqlParameter("@ToDate", paymentmodel.ToDate);
            SqlParameter p3 = new SqlParameter("@PanditID", paymentmodel.PanditId1);


            SqlParameter flag = new SqlParameter("@Flag", "10");
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditOrderHistory", p1, p2, p3, flag);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PaymentModel model = new PaymentModel();
                    model.customername = (dt.Rows[i]["FirstName_Call"]).ToString();
                    model.Servicename = dt.Rows[i]["Specialization"].ToString();
                    model.receiveddate = dt.Rows[i]["Received_Date"].ToString();
                    model.amount = Convert.ToInt64(dt.Rows[i]["Price"]);
                    model.duration = dt.Rows[i]["Duration"].ToString();
                    model.Bookingid = Convert.ToInt64(dt.Rows[i]["ID"]);
                    list.Add(model);
                }


            }
            return list;
        }


        public int SavePayment(int id)
        {
            int res = 0;

            SqlParameter p1 = new SqlParameter("@Orderid", id);
            SqlParameter flag = new SqlParameter("@Flag", "11");

            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_PanditOrderHistory", p1, flag);

            return res;

        }

        public int updatePayment(int id)
        {
            int res = 0;

            SqlParameter p1 = new SqlParameter("@Orderid", id);
            SqlParameter flag = new SqlParameter("@Flag", "12");

            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_PanditOrderHistory", p1, flag);

            return res;

        }
    }
}

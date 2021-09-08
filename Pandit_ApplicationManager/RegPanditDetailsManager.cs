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
    public class RegPanditDetailsManager
    {
        public List<RegPanditDetailsModel> DisplayProfile(int? PanditID)
        {
            List<RegPanditDetailsModel> listRegPanditDetailsModel = new List<RegPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@IDPandit", PanditID);
                SqlParameter flag = new SqlParameter("@flag", "18");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1, flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegPanditDetailsModel regpanditdetailsmodel = new RegPanditDetailsModel();
                        regpanditdetailsmodel.ID = dt.Rows[i]["ID"].ToString();
                        regpanditdetailsmodel.Fullname = dt.Rows[i]["FullName"].ToString();
                        regpanditdetailsmodel.DateofBirth = dt.Rows[i]["DOB"].ToString();
                        regpanditdetailsmodel.Gender = dt.Rows[i]["Gender"].ToString();
                        regpanditdetailsmodel.Address = dt.Rows[i]["Address"].ToString();
                        regpanditdetailsmodel.City = dt.Rows[i]["City"].ToString();
                        regpanditdetailsmodel.State = dt.Rows[i]["State"].ToString();
                        regpanditdetailsmodel.Country = dt.Rows[i]["Country"].ToString();
                        regpanditdetailsmodel.Pin = dt.Rows[i]["Zip"].ToString();
                        regpanditdetailsmodel.AboutSelf = dt.Rows[i]["AboutSelf"].ToString();
                        regpanditdetailsmodel.EmailAddress = dt.Rows[i]["Email"].ToString();
                        regpanditdetailsmodel.PhoneNumber = dt.Rows[i]["Mobile"].ToString();
                        regpanditdetailsmodel.YearsOfExperience = dt.Rows[i]["Year_of_Experience"].ToString();


                        regpanditdetailsmodel.ProfileImage = (byte[])dt.Rows[i]["ProfileImage"];

                        regpanditdetailsmodel.GovernmentId = (byte[])dt.Rows[i]["GovernmentId"];
                        regpanditdetailsmodel.GovernmentIdFileName = dt.Rows[i]["GovernmentIdFileName"].ToString();
                        regpanditdetailsmodel.GovernmentIdContentType = dt.Rows[i]["GovernmentIdContentType"].ToString();

                        regpanditdetailsmodel.BioData2 = (byte[])dt.Rows[i]["BioData2"];
                        regpanditdetailsmodel.BioDataFileName = dt.Rows[i]["BioDataFileName"].ToString();
                        regpanditdetailsmodel.BioDataContentType = dt.Rows[i]["BioDataContentType"].ToString();


                        regpanditdetailsmodel.Hindi = dt.Rows[i]["Hindi"].ToString();
                        regpanditdetailsmodel.English = dt.Rows[i]["English"].ToString();
                        regpanditdetailsmodel.Spanish = dt.Rows[i]["Spanish"].ToString();
                        regpanditdetailsmodel.French = dt.Rows[i]["French"].ToString();
                        regpanditdetailsmodel.German = dt.Rows[i]["German"].ToString();
                        regpanditdetailsmodel.Bengali = dt.Rows[i]["Bengali"].ToString();
                        regpanditdetailsmodel.urdu = dt.Rows[i]["urdu"].ToString();
                        regpanditdetailsmodel.Tamil = dt.Rows[i]["Tamil"].ToString();

                        listRegPanditDetailsModel.Add(regpanditdetailsmodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listRegPanditDetailsModel;
        }

        public List<RegPanditDetailsModel> BindPujas(int? PanditID)
        {
            List<RegPanditDetailsModel> list = new List<RegPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "2");
                SqlParameter p2 = new SqlParameter("@PanditID", PanditID);
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details", p1, p2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegPanditDetailsModel model = new RegPanditDetailsModel();
                        model.Puja_Snum = dt.Rows[i]["Serial_Number"].ToString();
                        model.PujasName = dt.Rows[i]["Pujasname"].ToString();
                        model.pujaPriceINR = dt.Rows[i]["pujapriceINR"].ToString();
                        model.pujaPriceUs = dt.Rows[i]["Price"].ToString();
                        list.Add(model);
                    }
                }






                //DataSet ds = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details", p1, p2);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    for(int i=0; i < ds.Tables[0].Rows.Count;i++)
                //    {
                //        RegPanditDetailsModel model = new RegPanditDetailsModel();
                //        model.Puja_Snum = ds.Tables[0].Rows[i]["Serial_Number"].ToString();
                //        model.PujasName = ds.Tables[0].Rows[i]["Pujasname"].ToString();
                //        model.pujaPriceINR = ds.Tables[0].Rows[i]["pujapriceINR"].ToString();
                //        model.pujaPriceUs = ds.Tables[0].Rows[i]["Price"].ToString();
                //        list.Add(model);
                //    }
                //}


                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                //    {
                //        RegPanditDetailsModel model = new RegPanditDetailsModel();
                //        model.Service_Snum = ds.Tables[1].Rows[j]["Serial_Number"].ToString();
                //        model.Servicename = ds.Tables[1].Rows[j]["Servicename"].ToString();
                //        model.ServicePriceUS = ds.Tables[1].Rows[j]["ServicePrice"].ToString();
                //        model.ServicePriceINR = ds.Tables[1].Rows[j]["servicespriceINR"].ToString();
                //        list.Add(model);
                //    }
                //}
                //if (ds.Tables[2].Rows.Count > 0)
                //{
                //    for (int k = 0; k < ds.Tables[2].Rows.Count; k++)
                //    {
                //        RegPanditDetailsModel model = new RegPanditDetailsModel();
                //        model.Report_Snum = ds.Tables[2].Rows[k]["Serial_Number"].ToString();
                //        model.ReportName = ds.Tables[2].Rows[k]["ReportName"].ToString();
                //        model.ReportPriceUS = ds.Tables[2].Rows[k]["Price"].ToString();
                //        model.ReportPriceINR = ds.Tables[2].Rows[k]["ReportChargesINR"].ToString();
                //        list.Add(model);
                //    }
                //}

            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public List<RegPanditDetailsModel> BindServices(int? PanditID)
        {
            List<RegPanditDetailsModel> list = new List<RegPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "3");
                SqlParameter p2 = new SqlParameter("@PanditID", PanditID);
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details", p1, p2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegPanditDetailsModel model = new RegPanditDetailsModel();
                        model.Service_Snum = dt.Rows[i]["Serial_Number"].ToString();
                        model.Servicename = dt.Rows[i]["Servicename"].ToString();
                        model.ServicePriceUS = dt.Rows[i]["ServicePrice"].ToString();
                        model.ServicePriceINR = dt.Rows[i]["servicespriceINR"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }


        public List<RegPanditDetailsModel> BindReports(int? PanditID)
        {
            List<RegPanditDetailsModel> list = new List<RegPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "4");
                SqlParameter p2 = new SqlParameter("@PanditID", PanditID);
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details", p1, p2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegPanditDetailsModel model = new RegPanditDetailsModel();
                        model.Report_Snum = dt.Rows[i]["Serial_Number"].ToString();
                        model.ReportName = dt.Rows[i]["ReportName"].ToString();
                        model.ReportPriceUS = dt.Rows[i]["Price"].ToString();
                        model.ReportPriceINR = dt.Rows[i]["ReportChargesINR"].ToString();
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }


        public List<RegPanditDetailsModel> CallChat(int? PanditID)
        {
            List<RegPanditDetailsModel> list = new List<RegPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "5");
                SqlParameter p2 = new SqlParameter("@PanditID", PanditID);
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details", p1, p2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegPanditDetailsModel model = new RegPanditDetailsModel();
                        model.Call_Rate_USD = dt.Rows[i]["Call_rate_USD"].ToString();
                        model.Call_Rate_INR = dt.Rows[i]["Call_rate_INR"].ToString();
                        model.Chat_Rate_USD = dt.Rows[i]["Chat_Rate_USD"].ToString();
                        model.Chat_Rate_INR = dt.Rows[i]["Chat_Rate_INR"].ToString();
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

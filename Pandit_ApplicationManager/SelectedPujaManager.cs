using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandit_ApplicationManager;
using Pandit_ApplicationEntity;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace Pandit_ApplicationManager
{
   public class SelectedPujaManager
    {
        public int SavePujaBookingDetails( SelectedPujaModel model)
        {
            List<SelectedPujaModel> listpujamodel = new List<SelectedPujaModel>();
            int res = 0;
            try
            {
               
                SqlParameter p1 = new SqlParameter("@Name",model.name);
                SqlParameter p2 = new SqlParameter("@Mobile", model.Mobile);
                SqlParameter p3 = new SqlParameter("@DateOfBirth", model.DOB);
                SqlParameter p4 = new SqlParameter("@Gender", model.Gender);
                SqlParameter p5 = new SqlParameter("@Martial_Status", model.Martial_Status);
                SqlParameter p6 = new SqlParameter("@Address", model.Address);
                SqlParameter p7 = new SqlParameter("@Comment", model.Comment);
                SqlParameter p9 = new SqlParameter("@TimeOfBirth", model.TimeOfBirth);
                SqlParameter p10 = new SqlParameter("@Occupation", model.Occupation);
                SqlParameter p11 = new SqlParameter("@Email", model.Email);
                SqlParameter p12 = new SqlParameter("@PreferredLang", model.PreferredLang);
                SqlParameter p13 = new SqlParameter("@CountryCode", model.CountryCode);
                SqlParameter p14 = new SqlParameter("@ServiceID", model.ServiceID);
                SqlParameter p15 = new SqlParameter("@Servicename", model.Servicename);
                SqlParameter p16 = new SqlParameter("@CustId", model.CustomerID);
                SqlParameter p17 = new SqlParameter("@CityofBirth", model.CityOfBirth);
                SqlParameter p21 = new SqlParameter("@stateofBirth", model.StateofBirth);
                SqlParameter p22 = new SqlParameter("@countryofBirth", model.CountryofBirth);
                SqlParameter p23 = new SqlParameter("@City", model.City);
                SqlParameter p24 = new SqlParameter("@State", model.State);
                SqlParameter p25 = new SqlParameter("@Country", model.Country);
                SqlParameter p26 = new SqlParameter("@Zip", model.Zip);
                SqlParameter p27 = new SqlParameter("@AddressID", model.Addressid == "" || model.Addressid == null || model.Addressid == "undefined" ? "0" : model.Addressid);
                SqlParameter p28 = new SqlParameter("@PanditID", model.PanditID);





                SqlParameter p8 = new SqlParameter("@Flag",'1');

                DataSet dt = new DataSet();
                dt = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_Customer_Puja_Master", p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p21,p22,p23,p24,p25,p26,p27,p28);
                //if (dt.Rows.Count > 0 && dt != null)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        SelectedPujaModel selectedPujaModel = new SelectedPujaModel();
                //        selectedPujaModel.name = dt.Rows[i]["Name"].ToString();
                //        selectedPujaModel.Mobile = Convert.ToInt64(dt.Rows[i]["Mobile"].ToString());
                //        selectedPujaModel.DOB = dt.Rows[i]["DateOfBirth"].ToString();
                //        selectedPujaModel.Month = dt.Rows[i]["Description"].ToString();
                //        selectedPujaModel.Martial_Status = dt.Rows[i]["Martial_Status"].ToString();
                //        selectedPujaModel.Address = dt.Rows[i]["Address"].ToString();
                //        selectedPujaModel.Comment = dt.Rows[i]["Comment"].ToString();
                //        selectedPujaModel.TimeOfBirth = dt.Rows[i]["TimeOfBirth"].ToString();
                //        selectedPujaModel.Occupation = dt.Rows[i]["Occupation"].ToString();
                //        listpujamodel.Add(model);


                //    }
                //}

                if (dt != null && dt.Tables.Count > 0)
                {
                    res = Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
                    if(dt.Tables[1].Rows.Count > 0)
                    {
                        for(int i = 0; i < dt.Tables[1].Rows.Count; i++)
                        {
                            SqlParameter p19 = new SqlParameter("@PanditID",dt.Tables[1].Rows[i]["PanditID"]);
                            SqlParameter p18 = new SqlParameter("@Customer_puja_ID", res);
                            SqlParameter p20 = new SqlParameter("@Flag", '2');
                            int result = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Customer_Puja_Master", p14, p15, p16,p18,p20,p19);
                        }
                    }
                }
                else
                {
                    res = -1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;

        }

        public List<SelectedPujaModel> Bindaddress(long CustID)
        {
            List<SelectedPujaModel> list = new List<SelectedPujaModel>();

            SqlParameter p1 = new SqlParameter("@CustID", CustID);
            SqlParameter flg = new SqlParameter("@Flag", '2');
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Customer_Call_Chat_details", p1, flg);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SelectedPujaModel model = new SelectedPujaModel();
                    model.Address = dt.Rows[i]["Address"].ToString();
                    model.City = dt.Rows[i]["City"].ToString();
                    model.State = dt.Rows[i]["State"].ToString();
                    model.Country = dt.Rows[i]["Country"].ToString();
                    model.Zip = dt.Rows[i]["Zip"].ToString();
                    model.Addressid = dt.Rows[i]["AddressID"].ToString();
                    model.completeaddress = dt.Rows[i]["Address"].ToString() + "," + dt.Rows[i]["City"].ToString() + "," + dt.Rows[i]["State"].ToString() + "," + dt.Rows[i]["Country"].ToString() + "," + dt.Rows[i]["Zip"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        public SelectedPujaModel GetServicesAmount(long ID, string Servicename, int panditID)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@ServiceID", ID);
            SqlParameter p2 = new SqlParameter("@Servicename", Servicename);
            SqlParameter p3 = new SqlParameter("@PanditID", panditID);
            SqlParameter p4 = new SqlParameter("@Flag", '3');
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Customer_Puja_Master", p1, p2, p3, p4);
            SelectedPujaModel model = new SelectedPujaModel();
            if(dt.Rows.Count>0 && dt != null)
            {
                model.amount = Convert.ToInt32(dt.Rows[0]["Price"]);
                model.Servicename = dt.Rows[0]["Servicename"].ToString();
            }
            return model;
            
        }
    }
}

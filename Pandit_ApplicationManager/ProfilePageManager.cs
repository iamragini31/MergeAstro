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
    public class ProfilePageManager
    {
        public List<ProfilePageModel> FetchPanditDetailsForProfile(int panditid)
        {
            List<ProfilePageModel> listProfilePageModel = new List<ProfilePageModel>();

            try
            {
                SqlParameter p1 = new SqlParameter("@PanditID", panditid);
                SqlParameter flag = new SqlParameter("@flag", "1");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details_For_Profile", flag, p1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProfilePageModel profilePageModel = new ProfilePageModel();
                        profilePageModel.Fullname = dt.Rows[i]["FullName"].ToString();
                        profilePageModel.Gender = dt.Rows[i]["Gender"].ToString();
                        profilePageModel.DateofBirth = dt.Rows[i]["DOB"].ToString();
                        profilePageModel.EmailAddress = dt.Rows[i]["Email"].ToString();
                        profilePageModel.PhoneNumber = dt.Rows[i]["Mobile"].ToString();
                        profilePageModel.Address = dt.Rows[i]["Address"].ToString();
                        profilePageModel.City = dt.Rows[i]["City"].ToString();
                        profilePageModel.State = dt.Rows[i]["State"].ToString();
                        profilePageModel.Country = dt.Rows[i]["country"].ToString();
                        profilePageModel.Zip = dt.Rows[i]["Zip"].ToString();
                        profilePageModel.YearsOfExperience = dt.Rows[i]["Year_of_Experience"].ToString();
                        profilePageModel.TaxIdNumber = dt.Rows[i]["TaxIdNumber"].ToString();
                        profilePageModel.Hindi = dt.Rows[i]["Hindi"].ToString();
                        profilePageModel.English = dt.Rows[i]["English"].ToString();
                        profilePageModel.Spanish = dt.Rows[i]["Spanish"].ToString();
                        profilePageModel.French = dt.Rows[i]["French"].ToString();
                        profilePageModel.German = dt.Rows[i]["German"].ToString();
                        profilePageModel.Bengali = dt.Rows[i]["Bengali"].ToString();
                        profilePageModel.urdu = dt.Rows[i]["urdu"].ToString();
                        profilePageModel.Tamil = dt.Rows[i]["Tamil"].ToString();

                        profilePageModel.PackageName = dt.Rows[i]["PackageName"].ToString();
                        //profilePageModel.Price = dt.Rows[i]["Price"].ToString();
                        //profilePageModel.Description = dt.Rows[i]["Description"].ToString();


                        profilePageModel.ChargesForCallPerMinu = dt.Rows[i]["Charges_Call_per_Minu"].ToString();
                        profilePageModel.ChargesForChatPerMinu = dt.Rows[i]["Chat_Call_per_Minu"].ToString();

                        //profilePageModel.PanditID = Convert.ToInt64(dt.Rows[i]["Id"].ToString());
                        listProfilePageModel.Add(profilePageModel);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listProfilePageModel;
        }



        public List<ProfilePageModel> PaymentOption(int panditid)


        {
            List<ProfilePageModel> list = new List<ProfilePageModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@PanditID", panditid);
                SqlParameter flag = new SqlParameter("@flag", "2");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details_For_Profile", flag, p1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProfilePageModel profilePageModel = new ProfilePageModel();




                        profilePageModel.Payment_Method = dt.Rows[i]["Payment_Method"].ToString();
                        profilePageModel.Bank_Name = dt.Rows[i]["Bank_Name"].ToString();
                        profilePageModel.Account_Number = dt.Rows[i]["Account_Number"].ToString();
                        profilePageModel.Account_holder_name = dt.Rows[i]["Account_holder_name"].ToString();
                        profilePageModel.Routing_Number = dt.Rows[i]["Routing_Number"].ToString();
                        profilePageModel.Email_address = dt.Rows[i]["Email_address"].ToString();
                        profilePageModel.PaypalAccountnumber = dt.Rows[i]["PaypalAccountnumber"].ToString();
                        profilePageModel.Google_Pay_ID = dt.Rows[i]["Google_Pay_ID"].ToString();
                        profilePageModel.PhoneNumber = dt.Rows[i]["Phone_number"].ToString();

                        list.Add(profilePageModel);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }


        public List<ProfilePageModel> DisplayPuja(int panditid)


        {
            List<ProfilePageModel> list = new List<ProfilePageModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@PanditID", panditid);
                SqlParameter flag = new SqlParameter("@flag", "3");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details_For_Profile", flag, p1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProfilePageModel profilePageModel = new ProfilePageModel();
                        profilePageModel.Pujasname = dt.Rows[i]["Pujasname"].ToString();
                        profilePageModel.Price = dt.Rows[i]["Price"].ToString();
                        list.Add(profilePageModel);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<ProfilePageModel> DisplayServices(int panditid)


        {
            List<ProfilePageModel> list = new List<ProfilePageModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@PanditID", panditid);
                SqlParameter flag = new SqlParameter("@flag", "4");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Fetch_Pandit_Details_For_Profile", flag, p1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProfilePageModel profilePageModel = new ProfilePageModel();
                        profilePageModel.servicename = dt.Rows[i]["servicename"].ToString();
                        profilePageModel.ServicePrice = dt.Rows[i]["ServicePrice"].ToString();
                        list.Add(profilePageModel);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}

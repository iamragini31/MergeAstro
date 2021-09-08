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
    public class RegisterForm2Manager
    {


        public List<RegisterForm2Model> GetAllSkills()
        {
            List<RegisterForm2Model> List = new List<RegisterForm2Model>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "6");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_master", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegisterForm2Model registerform2model = new RegisterForm2Model();
                        registerform2model.skills = dt.Rows[i]["Servicename"].ToString();
                        List.Add(registerform2model);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }

        public int SavePanditskill(string servicename, string servicesprice,string servicespriceINR, int PanditID)
        {
            SqlParameter p1 = new SqlParameter("@Servicename", servicename);
            SqlParameter p2 = new SqlParameter("@ServicePrice", servicesprice);
            SqlParameter p2a = new SqlParameter("@servicespriceINR", servicespriceINR);
            SqlParameter p3 = new SqlParameter("@PanditID", PanditID);
            SqlParameter flag = new SqlParameter("@Flag", "2");

            int res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Services_master", p1, p2, p2a, p3, flag);
            return res;
        }

        public List<RegisterForm2Model> GetAllPuja()
        {
            List<RegisterForm2Model> List = new List<RegisterForm2Model>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "9");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegisterForm2Model registerform2model = new RegisterForm2Model();
                        registerform2model.puja = dt.Rows[i]["Pujasname"].ToString();
                        List.Add(registerform2model);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }

        public int SavePanditPuja(string pujaname, string pujaprice,string pujapriceINR, int PanditID)
        {
            SqlParameter p1 = new SqlParameter("@Pujaname", pujaname);
            SqlParameter p2 = new SqlParameter("@Pujaprice", pujaprice);
            SqlParameter p2a = new SqlParameter("@pujapriceINR", pujapriceINR);
            SqlParameter p3 = new SqlParameter("@PanditID", PanditID);
            SqlParameter flag = new SqlParameter("@Flag", "2");

            int res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Puja_master", p1, p2, p2a, p3, flag);
            return res;
        }


        public List<RegisterForm2Model> Bindpackages()


        {
            List<RegisterForm2Model> list = new List<RegisterForm2Model>();
            try
            {
                SqlParameter flag = new SqlParameter("@Flag", '1');
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Package_Master", flag);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        RegisterForm2Model registermodel = new RegisterForm2Model();
                        registermodel.packageID = Convert.ToInt64(dt.Rows[i]["ID"]);
                        registermodel.PackageName = (dt.Rows[i]["PackageName"].ToString());
                        registermodel.packageprice = Convert.ToInt64(dt.Rows[i]["Price"]);
                        registermodel.packageDescription = (dt.Rows[i]["Description"].ToString());
                        list.Add(registermodel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public int Submitpayment(RegisterForm2Model model, int PanditID, string TaxIdNumber, string DisplayName, string OtherOrganisationDetails)
        {
            int res = 0;
            try
            {
                SqlParameter p1 = new SqlParameter("@Bank_Name", model.BankName);
                SqlParameter p2 = new SqlParameter("@Account_Number", model.AccNumber);
                SqlParameter p3 = new SqlParameter("@Account_holder_name", model.AccHolderName);
                SqlParameter p4 = new SqlParameter("@IFSC_Code", model.IFSCCode);
                SqlParameter p5 = new SqlParameter("@Routing_Number", model.RoutingNum);
                SqlParameter p5a = new SqlParameter("@Email_address", model.Email_Bank);
                SqlParameter p6 = new SqlParameter("@Charges_Call_per_Minu", model.ChargesForCall);
                SqlParameter p6a = new SqlParameter("@ChargesForCallINR", model.ChargesForCallINR);
                SqlParameter p7 = new SqlParameter("@Chat_Call_per_Minu", model.ChargesForChat);
                SqlParameter p7a = new SqlParameter("@ChargesForChatINR", model.ChargesForChatINR);
                SqlParameter p8 = new SqlParameter("@IDPandit", PanditID);
                SqlParameter p9 = new SqlParameter("@PackageID", model.packageID);
                SqlParameter p10 = new SqlParameter("@Payment_Method", model.Paymentoption);
                SqlParameter p11 = new SqlParameter("@TaxIdNumber", TaxIdNumber);
                SqlParameter p11a = new SqlParameter("@DisplayName", DisplayName);
                SqlParameter p11b = new SqlParameter("@OtherOrganisationDetails", OtherOrganisationDetails);
                //Added by Mah
                SqlParameter p16 = new SqlParameter("@TaxIDImage", model.TaxIDImage);
                SqlParameter p17 = new SqlParameter("@TaxIDImagePath", model.TaxIDImagePath);
                SqlParameter p18 = new SqlParameter("@TaxIDImagecontent", model.TaxIDImagecontent);

                SqlParameter p12 = new SqlParameter("@Phone_number", model.PhoneNumberZelle);
                SqlParameter p13 = new SqlParameter("@Email_Zelle", model.EmailZelle);
                SqlParameter p14 = new SqlParameter("@PaypalAccountnumber", model.PaypalAccountNumber);
                SqlParameter p14a = new SqlParameter("@Email_Paypal", model.Email_Paypal);
                SqlParameter p15 = new SqlParameter("@Google_Pay_ID", model.GooglePayId);
                SqlParameter flag = new SqlParameter("@Flag", '1');
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_TaxIdForPanditRegistration", p1, p2, p3, p4, p5,p5a, p6, p6a, p7, p7a, p8, p9, p10, p11,p11a,p11b ,p16,p17,p18,p12,p13,p14,p14a,p15,flag);
            }
            catch (Exception ex)
            {

            }
            return res;
        }


        //   Added by mah
        public List<RegisterForm2Model> GetDetailReport()
        {
            List<RegisterForm2Model> List = new List<RegisterForm2Model>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "4");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Detailed_Reports", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegisterForm2Model registerform2model = new RegisterForm2Model();
                        registerform2model.DetailedReport = dt.Rows[i]["ReportName"].ToString();
                        registerform2model.ReportId = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        List.Add(registerform2model);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }

        public int SaveReports(DataTable postdata, string ReportCharges, long Panditid)
        {
            int res = 0;
            try
            {

                if (postdata.Rows.Count > 0 && postdata != null)
                {
                    for (int i = 0; i < postdata.Rows.Count; i++)
                    {

                        SqlParameter p1 = new SqlParameter("@ReportID", postdata.Rows[i]["ReportId"]);
                        SqlParameter p3 = new SqlParameter("@Price", ReportCharges);
                        //SqlParameter p3a = new SqlParameter("@ReportChargesINR", ReportChargesINR);
                        SqlParameter p2 = new SqlParameter("@PanditID", Panditid);
                        SqlParameter flag = new SqlParameter("@Flag", '2');
                        res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Detailed_Reports", p1, p2, p3, flag);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;

        }




    }
}

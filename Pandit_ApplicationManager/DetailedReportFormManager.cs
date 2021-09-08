using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pandit_ApplicationEntity;
using System.Data;
using System.Data.SqlClient;

namespace Pandit_ApplicationManager
{
   public class DetailedReportFormManager
    {

        public int SaveDetailReport(DetailedReportFormModel model)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@CustID", model.CustomerID);
            SqlParameter p2 = new SqlParameter("@FullName", model.name);
            SqlParameter p3 = new SqlParameter("@CountryCode", model.CountryCode);

            SqlParameter p4 = new SqlParameter("@Gender", model.gender);
            SqlParameter p5 = new SqlParameter("@Mobile", model.Mobile);

            SqlParameter p6 = new SqlParameter("@DOB", model.DOB);
            SqlParameter p7 = new SqlParameter("@TimeOFBirth", model.TimeOfBirth);

            SqlParameter p8 = new SqlParameter("@City", model.City);
            SqlParameter p9 = new SqlParameter("@State", model.State);
            SqlParameter p10 = new SqlParameter("@Country", model.Country);
            SqlParameter p11 = new SqlParameter("@MaritalStatus", model.Martial_Status);
            SqlParameter p12 = new SqlParameter("@PrefferedLang", model.PreferredLang);
            SqlParameter p13 = new SqlParameter("@NotesToPandit", model.TopicforCall);
            SqlParameter p14 = new SqlParameter("@Panditid", model.PanditID);
            SqlParameter p15 = new SqlParameter("@ReportId", model.ReportID);
            //SqlParameter p16 = new SqlParameter("@Service", model.Service);
            //new

            SqlParameter p17 = new SqlParameter("@CityOfBirth", model.CityOfBirth);
            SqlParameter p18 = new SqlParameter("@StateOfBirth", model.StateofBirth);
            SqlParameter p19 = new SqlParameter("@CountryOfBirth", model.CountryofBirth);
            SqlParameter p20 = new SqlParameter("@Occupation", model.Occupation);
            SqlParameter p21 = new SqlParameter("@Address", model.Address);
            SqlParameter p22 = new SqlParameter("@Zip", model.Zip);
            SqlParameter p22a = new SqlParameter("@Service", model.Servicename);
            SqlParameter p23 = new SqlParameter("@AddressID", model.Addressid == "" || model.Addressid == null || model.Addressid== "undefined" ? "0" : model.Addressid);
            //For Partner Details
            SqlParameter p24 = new SqlParameter("@PName", model.Ptrtxtname);
            SqlParameter p25 = new SqlParameter("@PGender", model.Ptrddlgender);
            SqlParameter p26 = new SqlParameter("@PMaritalStatus", model.PtrddlMartial_Status);
            SqlParameter p27 = new SqlParameter("@PDOB", model.PtrDOB);
            SqlParameter p28 = new SqlParameter("@PTimeOfBirth", model.PtrtxtTimeOfBirth);
            SqlParameter p29 = new SqlParameter("@PCityOfBirth", model.Ptrtxtcityofbirth);
            SqlParameter p30 = new SqlParameter("@PStateOfBirth", model.PtrtxtstateofBirth);
            SqlParameter p31 = new SqlParameter("@PCountryOfBirth", model.Ptrtxtcountryofbirth);
            SqlParameter p32 = new SqlParameter("@PAddress", model.PtrtxtAddress);
            SqlParameter p33 = new SqlParameter("@PCity", model.Ptrtxtcity);
            SqlParameter p34 = new SqlParameter("@PState", model.Ptrtxtstate);
            SqlParameter p35 = new SqlParameter("@PCountry", model.PtrtxtCountry);
            SqlParameter p36 = new SqlParameter("@PZip", model.PtrtxtZip);






            SqlParameter flag = new SqlParameter("@Flag", '1');
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Customer_DetailedReport", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15,
                p17, p18, p19, p20, p21, p22, p22a, p23,p25,p26,p27,p28,p29,p30,p31,p32,p33,p34,p35,p36, flag);

            return res;
        }
        public DetailedReportFormModel GetServicesAmount(long ID, int panditID)
        {

            SqlParameter p1 = new SqlParameter("@ReportID", ID);
            SqlParameter p3 = new SqlParameter("@PanditID", panditID);
            SqlParameter p4 = new SqlParameter("@Flag", '4');
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Customer_DetailedReport", p1, p3, p4);
            DetailedReportFormModel model = new DetailedReportFormModel();
            if (dt.Rows.Count > 0 && dt != null)
            {
                model.amount = Convert.ToInt32(dt.Rows[0]["Price"]);
                model.Servicename = dt.Rows[0]["ReportName"].ToString();
            }
            return model;

        }

    }
}

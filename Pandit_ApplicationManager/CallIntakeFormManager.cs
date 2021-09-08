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
   public class CallIntakeFormManager
    {


        public int SaveCall_Chat(CallIntakeFormModel model, int specilistid, int panditid, int custid)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@CustID", custid);
            SqlParameter p2 = new SqlParameter("@FirstName_Call", model.name);
            SqlParameter p3 = new SqlParameter("@CountryCode", model.CountryCode);

            SqlParameter p4 = new SqlParameter("@Gender", model.gender);
            SqlParameter p5 = new SqlParameter("@Mobile", model.Mobile);

            SqlParameter p6 = new SqlParameter("@DOB", model.DOB);
            SqlParameter p7 = new SqlParameter("@Time_of_Birth", model.TimeOfBirth);

            SqlParameter p8 = new SqlParameter("@City", model.City);
            SqlParameter p9 = new SqlParameter("@State", model.State);
            SqlParameter p10 = new SqlParameter("@Country", model.Country);
            SqlParameter p11 = new SqlParameter("@Martial_Status", model.Martial_Status);
            SqlParameter p12 = new SqlParameter("@PreferredLang", model.PreferredLang);
            SqlParameter p13 = new SqlParameter("@Topicforcall", model.TopicforCall);
            SqlParameter p14 = new SqlParameter("@Panditid", panditid);
            SqlParameter p15 = new SqlParameter("@Specilizationid", specilistid);
            SqlParameter p16 = new SqlParameter("@Service", model.Service);
            //new

            SqlParameter p17 = new SqlParameter("@CityofBirth", model.CityOfBirth);
            SqlParameter p18 = new SqlParameter("@stateofBirth", model.StateofBirth);
            SqlParameter p19 = new SqlParameter("@countryofBirth", model.CountryofBirth);
            SqlParameter p20 = new SqlParameter("@Occupation", model.Occupation);
            SqlParameter p21 = new SqlParameter("@Address", model.Address);
            SqlParameter p22 = new SqlParameter("@Zip", model.Zip);
            SqlParameter p23 = new SqlParameter("@AddressID", model.Addressid == "" || model.Addressid  == null || model.Addressid == "undefined" ? "0" :model.Addressid);

            SqlParameter flag = new SqlParameter("@Flag", '1');
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Customer_Call_Chat_details", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
                p17,p18,p19,p20,p21,p22,p23,flag);

            return res;
        }


        public List<CallIntakeFormModel> Bindaddress(long CustID)
        {
            List<CallIntakeFormModel> list = new List<CallIntakeFormModel>();

            SqlParameter p1 = new SqlParameter("@CustID", CustID);
            SqlParameter flg = new SqlParameter("@Flag", '2');
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Customer_Call_Chat_details", p1, flg);
            if(dt.Rows.Count> 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    CallIntakeFormModel model = new CallIntakeFormModel();
                    model.Address = dt.Rows[i]["Address"].ToString();
                    model.City = dt.Rows[i]["City"].ToString();
                    model.State = dt.Rows[i]["State"].ToString();
                    model.Country = dt.Rows[i]["Country"].ToString();
                    model.Zip = dt.Rows[i]["Zip"].ToString();
                    model.Addressid = dt.Rows[i]["AddressID"].ToString();
                    model.completeaddress = dt.Rows[i]["Address"].ToString() + "," + dt.Rows[i]["City"].ToString()+","+ dt.Rows[i]["State"].ToString()+","+ dt.Rows[i]["Country"].ToString()+","+dt.Rows[i]["Zip"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}

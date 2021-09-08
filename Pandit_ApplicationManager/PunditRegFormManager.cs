using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandit_ApplicationEntity;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace Pandit_ApplicationManager
{
    
    
  public  class PunditRegFormManager
    {
        PunditRegFormModel punditregformmodel = new PunditRegFormModel();
        public List<PunditRegFormModel> GetAllSkills()
        {
            List<PunditRegFormModel> List = new List<PunditRegFormModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "1");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Language_Master", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PunditRegFormModel panditmodel = new PunditRegFormModel();
                        panditmodel.lang = dt.Rows[i]["LAnguage"].ToString();
                        panditmodel.LangID = Convert.ToInt64(dt.Rows[i]["ID"]);
                        List.Add(panditmodel);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }

        public List<PunditRegFormModel> GetAllSpecialization()
        {
            List<PunditRegFormModel> List = new List<PunditRegFormModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "1");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Field_specialization", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PunditRegFormModel panditmodel = new PunditRegFormModel();
                        panditmodel.Specialization = dt.Rows[i]["Specialization"].ToString();



                        List.Add(panditmodel);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }
        public int SavePandit(PunditRegFormModel panditmodel)
        {
            string password = RandomPassword();
            int res = 0;
            SqlParameter p1 = new SqlParameter("@AboutSelf", panditmodel.AboutSelf);
            SqlParameter p2 = new SqlParameter("@Address", panditmodel.Address);
            SqlParameter p3 = new SqlParameter("@Bengali", panditmodel.Bengali == "undefined" ? " " : panditmodel.Bengali);
            SqlParameter p4 = new SqlParameter("@Profile", panditmodel.imageSrc);

            // PROFILEINBYTE
            SqlParameter p4a = new SqlParameter("@ProfileImage", panditmodel.ProfileImage);
            SqlParameter p4b = new SqlParameter("@ProfileFileName", panditmodel.ProfileImagePath);
            SqlParameter p4c = new SqlParameter("@ProfileContentType", panditmodel.ProfileImageContent);


            SqlParameter p5 = new SqlParameter("@City", panditmodel.City);
            SqlParameter p6 = new SqlParameter("@Country", panditmodel.Country);
            SqlParameter p7 = new SqlParameter("@Countrycode", panditmodel.Countrycode);
            SqlParameter p8 = new SqlParameter("@DOB", panditmodel.DOB);
            SqlParameter p9 = new SqlParameter("@Email", panditmodel.Email);
            SqlParameter p10 = new SqlParameter("@English", panditmodel.English == "undefined" ? " " : panditmodel.English);
            SqlParameter p11 = new SqlParameter("@French", panditmodel.French == "undefined" ? " " : panditmodel.French);
            SqlParameter p12 = new SqlParameter("@Hindi", panditmodel.Hindi == "undefined" ? " " : panditmodel.Hindi);
            SqlParameter p13 = new SqlParameter("@GovtID", panditmodel.imageSrc1);

            //GOVDID
            SqlParameter p13a = new SqlParameter("@GovernmentId", panditmodel.GovernmentId);
            SqlParameter p13b = new SqlParameter("@GovernmentIdFileName", panditmodel.GovernmentIdPath);
            SqlParameter p13c = new SqlParameter("@GovernmentIdContentType", panditmodel.GovernmentIdContent);


            SqlParameter p14 = new SqlParameter("@Fullname", panditmodel.Fullname);
            SqlParameter p15 = new SqlParameter("@Gender", panditmodel.Gender);
            SqlParameter p16 = new SqlParameter("@German", panditmodel.German == "undefined" ? " " : panditmodel.German);
            SqlParameter p17 = new SqlParameter("@BioData", panditmodel.imageSrc2);

            //BIO Data
            SqlParameter p17a = new SqlParameter("@BioData2", panditmodel.BioData2);
            SqlParameter p17b = new SqlParameter("@BioDataFileName", panditmodel.BioDataPath);
            SqlParameter p17c = new SqlParameter("@BioDataContentType", panditmodel.BioDataPathContent);


            SqlParameter p18 = new SqlParameter("@Mobile", panditmodel.Mobile);
            SqlParameter p19 = new SqlParameter("@Month", panditmodel.Month);
            SqlParameter p20 = new SqlParameter("@Spanish", panditmodel.Spanish == "undefined" ? " " : panditmodel.Spanish);
            SqlParameter p21 = new SqlParameter("@State", panditmodel.State);
            SqlParameter p22 = new SqlParameter("@Tamil ", panditmodel.Tamil == "undefined" ? " " : panditmodel.Tamil);
            SqlParameter p23 = new SqlParameter("@Urdu", panditmodel.Urdu == "undefined" ? " " : panditmodel.Urdu);
            SqlParameter p24 = new SqlParameter("@Year", panditmodel.Year);
            SqlParameter p25 = new SqlParameter("@YearsofExperience", panditmodel.YearsofExperience);
            SqlParameter p26 = new SqlParameter("@Zip", panditmodel.Zip);
            SqlParameter p27 = new SqlParameter("@Password", password);
            SqlParameter flag = new SqlParameter("@Flag", "1");
            int result = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_PanditRegistration", p1, p2, p3, p4, p5, p6, p7,
                    p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, flag, p27
                    );
            if(result > 0)
            {

            SqlParameter flg = new SqlParameter("@Flag", "10");
            DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", flg);
            if (dt != null && dt.Rows.Count > 0)
            {
                res = Convert.ToInt32(dt.Rows[0][0].ToString());
                SqlParameter p28 = new SqlParameter("@Flag", "1");
                SqlParameter p29 = new SqlParameter("@ID", res);
                clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_UploadDocuments", p4a, p4b, p4c, p13a, p13b, p13c, p17a, p17b, p17c, p28, p29);
            }

            }
            return result;


        }


        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }


        public int SaveSpecilization(string specilization, int id)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@Specialization", specilization);
            SqlParameter p2 = new SqlParameter("@IDPandit", id);
            SqlParameter flag = new SqlParameter("@Flag", '3');
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_PanditRegistration", p1, p2, flag);
            return res;
        }
    }
}

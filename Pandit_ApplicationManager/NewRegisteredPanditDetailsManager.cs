using DataAccessLayer;
using Pandit_ApplicationEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationManager
{
  public  class NewRegisteredPanditDetailsManager
    {

        public List<NewRegisteredPanditDetailsModel> DisplayProfile(int? PanditID)
        {
            List<NewRegisteredPanditDetailsModel> listNewRegisteredPanditDetailsModel = new List<NewRegisteredPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@IDPandit", PanditID);
                SqlParameter flag = new SqlParameter("@flag", "7");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1, flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        NewRegisteredPanditDetailsModel newregisteredpanditdetailsmodel = new NewRegisteredPanditDetailsModel();
                        newregisteredpanditdetailsmodel.ID = dt.Rows[i]["ID"].ToString();
                        newregisteredpanditdetailsmodel.Fullname = dt.Rows[i]["FullName"].ToString();
                        newregisteredpanditdetailsmodel.DateofBirth = dt.Rows[i]["DOB"].ToString();
                        newregisteredpanditdetailsmodel.Gender = dt.Rows[i]["Gender"].ToString();
                        newregisteredpanditdetailsmodel.Address = dt.Rows[i]["Address"].ToString();
                        newregisteredpanditdetailsmodel.City = dt.Rows[i]["City"].ToString();
                        newregisteredpanditdetailsmodel.State = dt.Rows[i]["State"].ToString();
                        newregisteredpanditdetailsmodel.Country = dt.Rows[i]["Country"].ToString();
                        newregisteredpanditdetailsmodel.Pin = dt.Rows[i]["Zip"].ToString();
                        newregisteredpanditdetailsmodel.AboutSelf = dt.Rows[i]["AboutSelf"].ToString();
                        newregisteredpanditdetailsmodel.EmailAddress = dt.Rows[i]["Email"].ToString();
                        newregisteredpanditdetailsmodel.PhoneNumber = dt.Rows[i]["Mobile"].ToString();
                        newregisteredpanditdetailsmodel.YearsOfExperience = dt.Rows[i]["Year_of_Experience"].ToString();


                        newregisteredpanditdetailsmodel.ProfileImage = (byte[])dt.Rows[i]["ProfileImage"];

                        newregisteredpanditdetailsmodel.GovernmentId = (byte[])dt.Rows[i]["GovernmentId"];
                        newregisteredpanditdetailsmodel.GovernmentIdFileName = dt.Rows[i]["GovernmentIdFileName"].ToString();
                        newregisteredpanditdetailsmodel.GovernmentIdContentType = dt.Rows[i]["GovernmentIdContentType"].ToString();

                        newregisteredpanditdetailsmodel.BioData2 = (byte[])dt.Rows[i]["BioData2"];
                        newregisteredpanditdetailsmodel.BioDataFileName = dt.Rows[i]["BioDataFileName"].ToString();
                        newregisteredpanditdetailsmodel.BioDataContentType = dt.Rows[i]["BioDataContentType"].ToString();


                        newregisteredpanditdetailsmodel.Hindi = dt.Rows[i]["Hindi"].ToString();
                        newregisteredpanditdetailsmodel.English = dt.Rows[i]["English"].ToString();
                        newregisteredpanditdetailsmodel.Spanish = dt.Rows[i]["Spanish"].ToString();
                        newregisteredpanditdetailsmodel.French = dt.Rows[i]["French"].ToString();
                        newregisteredpanditdetailsmodel.German = dt.Rows[i]["German"].ToString();
                        newregisteredpanditdetailsmodel.Bengali = dt.Rows[i]["Bengali"].ToString();
                        newregisteredpanditdetailsmodel.urdu = dt.Rows[i]["urdu"].ToString();
                        newregisteredpanditdetailsmodel.Tamil = dt.Rows[i]["Tamil"].ToString();

                        listNewRegisteredPanditDetailsModel.Add(newregisteredpanditdetailsmodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listNewRegisteredPanditDetailsModel;
        }
        public List<NewRegisteredPanditDetailsModel> DisplayProfileVerfied(int? PanditID)
        {
            List<NewRegisteredPanditDetailsModel> listNewRegisteredPanditDetailsModel = new List<NewRegisteredPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@IDPandit", PanditID);
                SqlParameter flag = new SqlParameter("@flag", "19");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1, flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        NewRegisteredPanditDetailsModel newregisteredpanditdetailsmodel = new NewRegisteredPanditDetailsModel();
                        newregisteredpanditdetailsmodel.ID = dt.Rows[i]["ID"].ToString();
                        newregisteredpanditdetailsmodel.Fullname = dt.Rows[i]["FullName"].ToString();
                        newregisteredpanditdetailsmodel.DateofBirth = dt.Rows[i]["DOB"].ToString();
                        newregisteredpanditdetailsmodel.Gender = dt.Rows[i]["Gender"].ToString();
                        newregisteredpanditdetailsmodel.Address = dt.Rows[i]["Address"].ToString();
                        newregisteredpanditdetailsmodel.City = dt.Rows[i]["City"].ToString();
                        newregisteredpanditdetailsmodel.State = dt.Rows[i]["State"].ToString();
                        newregisteredpanditdetailsmodel.Country = dt.Rows[i]["Country"].ToString();
                        newregisteredpanditdetailsmodel.Pin = dt.Rows[i]["Zip"].ToString();
                        newregisteredpanditdetailsmodel.AboutSelf = dt.Rows[i]["AboutSelf"].ToString();
                        newregisteredpanditdetailsmodel.EmailAddress = dt.Rows[i]["Email"].ToString();
                        newregisteredpanditdetailsmodel.PhoneNumber = dt.Rows[i]["Mobile"].ToString();
                        newregisteredpanditdetailsmodel.YearsOfExperience = dt.Rows[i]["Year_of_Experience"].ToString();


                        newregisteredpanditdetailsmodel.ProfileImage = (byte[])dt.Rows[i]["ProfileImage"];

                        newregisteredpanditdetailsmodel.GovernmentId = (byte[])dt.Rows[i]["GovernmentId"];
                        newregisteredpanditdetailsmodel.GovernmentIdFileName = dt.Rows[i]["GovernmentIdFileName"].ToString();
                        newregisteredpanditdetailsmodel.GovernmentIdContentType = dt.Rows[i]["GovernmentIdContentType"].ToString();

                        newregisteredpanditdetailsmodel.BioData2 = (byte[])dt.Rows[i]["BioData2"];
                        newregisteredpanditdetailsmodel.BioDataFileName = dt.Rows[i]["BioDataFileName"].ToString();
                        newregisteredpanditdetailsmodel.BioDataContentType = dt.Rows[i]["BioDataContentType"].ToString();


                        newregisteredpanditdetailsmodel.Hindi = dt.Rows[i]["Hindi"].ToString();
                        newregisteredpanditdetailsmodel.English = dt.Rows[i]["English"].ToString();
                        newregisteredpanditdetailsmodel.Spanish = dt.Rows[i]["Spanish"].ToString();
                        newregisteredpanditdetailsmodel.French = dt.Rows[i]["French"].ToString();
                        newregisteredpanditdetailsmodel.German = dt.Rows[i]["German"].ToString();
                        newregisteredpanditdetailsmodel.Bengali = dt.Rows[i]["Bengali"].ToString();
                        newregisteredpanditdetailsmodel.urdu = dt.Rows[i]["urdu"].ToString();
                        newregisteredpanditdetailsmodel.Tamil = dt.Rows[i]["Tamil"].ToString();

                        listNewRegisteredPanditDetailsModel.Add(newregisteredpanditdetailsmodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listNewRegisteredPanditDetailsModel;
        }
        public int ValidationDone(int? PanditID)
        {
            int res;
            List<NewRegisteredPanditDetailsModel> listNewRegisteredPanditDetailsModel = new List<NewRegisteredPanditDetailsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@IDPandit", PanditID);
                SqlParameter flag = new SqlParameter("@flag", "8");
                // DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1, flag);
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_PanditRegistration", p1, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }



        public NewRegisteredPanditDetailsModel GetPanditIDPASS(int PAnditid)
        {
            NewRegisteredPanditDetailsModel model = new NewRegisteredPanditDetailsModel();
            SqlParameter p1 = new SqlParameter("@ID", PAnditid);

            SqlParameter flag = new SqlParameter("@Flag", '2');
            try
            {
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_LoginReDirect", p1, flag);
                if (dt.Rows.Count > 0)
                {
                    model.USerid = dt.Rows[0]["UserID"].ToString();
                    model.Password = dt.Rows[0]["Password"].ToString();
                    model.EmailAddress = dt.Rows[0]["Email"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }
    }
}

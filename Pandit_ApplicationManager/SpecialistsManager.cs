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
   public class SpecialistsManager
    {

        public List<SpecialistsModel> GetAllSpecialization()
        {
            List<SpecialistsModel> List = new List<SpecialistsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "1");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Field_specialization", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SpecialistsModel model = new SpecialistsModel();
                        model.Sprcilistname = dt.Rows[i]["Specialization"].ToString();
                        model.SpecialistID = Convert.ToInt32(dt.Rows[i]["Id"]);



                        List.Add(model);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }



        public List<SpecialistsModel> GetAllPuja()
        {
            List<SpecialistsModel> List = new List<SpecialistsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "1");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SpecialistsModel model = new SpecialistsModel();
                        model.Pujaname = dt.Rows[i]["Pujasname"].ToString();
                        model.PujaID = Convert.ToInt32(dt.Rows[i]["ID"]);



                        List.Add(model);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }


        public List<SpecialistsModel> GetSpecialistsImagesWithName()
        {
            List<SpecialistsModel> List = new List<SpecialistsModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "1");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Field_specialization", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SpecialistsModel model = new SpecialistsModel();
                        model.Specialization = dt.Rows[i]["Specialization"].ToString();
                        model.Images = dt.Rows[i]["Images"].ToString();

                        model.SpecialistID = Convert.ToInt32(dt.Rows[i]["ID"]);



                        List.Add(model);

                    }
                }


            }
            catch (Exception ex)
            {

            }
            return List;
        }

    }
}

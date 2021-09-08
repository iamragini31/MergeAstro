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
   public class ServicesManager
    {

        public List<ServicesModel> GetServicesWithDetails()
        {
            List<ServicesModel> List = new List<ServicesModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@Flag", "1");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_master", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ServicesModel model = new ServicesModel();
                        model.Servicename = dt.Rows[i]["Servicename"].ToString();
                        model.Price = dt.Rows[i]["price"].ToString();
                        model.Images = dt.Rows[i]["Images"].ToString();
                        model.Description = dt.Rows[i]["Description"].ToString();
                        model.ServiceID = (long)dt.Rows[i]["ID"];

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

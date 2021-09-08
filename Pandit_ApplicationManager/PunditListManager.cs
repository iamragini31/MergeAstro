using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace Pandit_ApplicationManager
{
  public  class PunditListManager
    {
        public List<PunditListModel> GetSpecialistsImagesWithName(long panditId)
        {
            List<PunditListModel> List = new List<PunditListModel>();
            try
            {
                SqlParameter p2 = new SqlParameter("@IDPandit", panditId);
                SqlParameter p1 = new SqlParameter("@Flag", "4");
                
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p2,p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PunditListModel model = new PunditListModel();
                        model.Specialization = dt.Rows[i]["Specialization"].ToString();
                        model.specialisation_ID = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        model.PanditID =Convert.ToInt64( dt.Rows[i]["PanditID"].ToString());
                        model.Fullname = dt.Rows[i]["Fullname"].ToString();
                        model.profile = dt.Rows[i]["profile"].ToString();
                        model.Charges_call_per_minu = Convert.ToDouble(dt.Rows[i]["Charges_call_per_minu"].ToString());
                        model.Chat_Call_per_Minu = Convert.ToDouble(dt.Rows[i]["Charges_chat_per_minu"]);


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

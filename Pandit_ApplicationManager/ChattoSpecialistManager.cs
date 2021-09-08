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
  public  class ChattoSpecialistManager
    {

        public List<ChattoSpecialistModel> GetSpecialistsImagesWithName()
        {
            List<ChattoSpecialistModel> List = new List<ChattoSpecialistModel>();
            try
            {
               
                SqlParameter p1 = new SqlParameter("@Flag", "4");

                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ChattoSpecialistModel model = new ChattoSpecialistModel();
                        model.Panditid = Convert.ToInt64(dt.Rows[i]["PanditID"].ToString());
                        model.Panditname = dt.Rows[i]["Fullname"].ToString();
                        model.Image = (byte[])dt.Rows[i]["ProfileImage"];
                        model.chatcharge = Convert.ToDouble(dt.Rows[i]["Charges_call_per_minu"].ToString());
                        model.callcharge = Convert.ToDouble(dt.Rows[i]["Charges_chat_per_minu"]);
                        model.Specilization = dt.Rows[i]["Specialization"].ToString();
                       
                        SqlParameter p2 = new SqlParameter("@IDPandit", model.Panditid);
                        SqlParameter flag = new SqlParameter("@Flag","11");
                        DataTable dtable = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p2, flag);
                        if (dt.Rows.Count > 0)
                        {
                            model.experience = dt.Rows[i]["Specialization"].ToString();
                        }
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

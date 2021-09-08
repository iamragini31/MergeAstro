using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pandit_ApplicationEntity;
namespace Pandit_ApplicationManager
{
 public   class SpecialistChatManager

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
                        string topspeilization = string.Empty;
                        string listspecilization = string.Empty;
                        ChattoSpecialistModel model = new ChattoSpecialistModel();
                        model.Panditid = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        model.Panditname = dt.Rows[i]["Fullname"].ToString();
                        model.DisplayName = dt.Rows[i]["DisplayName"].ToString();
                        model.Image = (byte[])dt.Rows[i]["ProfileImage"];
                        model.chatcharge = Convert.ToDouble(dt.Rows[i]["Charges_call_per_minu"].ToString());
                        model.callcharge = Convert.ToDouble(dt.Rows[i]["Charges_chat_per_minu"]);
                        model.experience = dt.Rows[i]["Year_of_Experience"].ToString();

                        SqlParameter p2 = new SqlParameter("@IDPandit", model.Panditid);
                        SqlParameter flag = new SqlParameter("@Flag", "11");
                        DataSet dtable = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_PanditRegistration", p2, flag);
                        if (dtable.Tables[0].Rows.Count > 0)
                        {
                            for(int j = 0; j < dtable.Tables[0].Rows.Count;j++)
                            {
                                if (j == 0)
                                {
                                    topspeilization = dtable.Tables[0].Rows[j]["Specialization"].ToString();
                                }
                                else
                                {
                                    topspeilization = topspeilization + "," + dtable.Tables[0].Rows[j]["Specialization"].ToString();
                                }
                            }
                            model.Specilization = topspeilization;
                            
                        }
                        if (dtable.Tables[1].Rows.Count > 0)
                        {
                            for (int j = 0; j < dtable.Tables[1].Rows.Count; j++)
                            {
                                if (j == 0)
                                {
                                    listspecilization = dtable.Tables[1].Rows[j]["Specialization"].ToString();
                                }
                                else
                                {
                                    listspecilization = listspecilization + "," + dtable.Tables[1].Rows[j]["Specialization"].ToString();
                                }
                            }
                            model.ListSpecilisation = listspecilization;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_ApplicationManager
{
    public class TalktoSpecialistManager
    {
        public List<TalktoSpecialistModel> GetSpecialistsImagesWithName()
        {
            List<TalktoSpecialistModel> list = new List<TalktoSpecialistModel>();
            try
            {

                SqlParameter p1 = new SqlParameter("@flag", "12");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string TopSpecialisation = string.Empty;
                        string listSpecialisation = string.Empty;
                        TalktoSpecialistModel model = new TalktoSpecialistModel();
                        model.PanditId = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        model.PanditName = dt.Rows[i]["Fullname"].ToString();
                        model.DisplayName = dt.Rows[i]["DisplayName"].ToString();
                        model.Image = (byte[])dt.Rows[i]["ProfileImage"];
                        model.chatcharge = Convert.ToDouble(dt.Rows[i]["Charges_chat_per_minu"].ToString());
                        model.callcharge = Convert.ToDouble(dt.Rows[i]["Charges_call_per_minu"]);
                        model.experience = dt.Rows[i]["Year_of_Experience"].ToString();

                        SqlParameter p2 = new SqlParameter("@IDPandit", model.PanditId);
                        SqlParameter flag = new SqlParameter("@flag", "11");
                        DataSet DTable = new DataSet();
                        DTable = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_PanditRegistration", p2, flag);
                        if (DTable.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < DTable.Tables[0].Rows.Count; j++)
                            {
                                if (j == 0)
                                {
                                    TopSpecialisation = DTable.Tables[0].Rows[j]["Specialization"].ToString();
                                }
                                else
                                {
                                    TopSpecialisation = TopSpecialisation + "," + DTable.Tables[0].Rows[j]["Specialization"].ToString();
                                }
                            }
                            model.Specialisation = TopSpecialisation;
                        }
                        if (DTable.Tables[1].Rows.Count > 0)
                        {
                            for (int j = 0; j < DTable.Tables[1].Rows.Count; j++)
                            {
                                if (j == 0)
                                {
                                    listSpecialisation = DTable.Tables[1].Rows[j]["Specialization"].ToString();
                                }
                                else
                                {
                                    listSpecialisation = listSpecialisation + "," + DTable.Tables[1].Rows[j].ToString();
                                }
                            }
                            model.listSpecialisation = listSpecialisation;
                        }
                        list.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }
    }

}

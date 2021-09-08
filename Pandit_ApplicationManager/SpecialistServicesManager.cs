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
  public  class SpecialistServicesManager
    {

        public List<ChattoSpecialistModel> GetSpecialistsImagesWithName(int PujaID,string Type)
        {
            List<ChattoSpecialistModel> List = new List<ChattoSpecialistModel>();
            try
            {
                DataTable dt = new DataTable();
                if (Type == "Puja")
                {
                    SqlParameter p1 = new SqlParameter("@Flag", "6");
                    SqlParameter p3 = new SqlParameter("@PujaID", PujaID);

                    dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", p1, p3);
                }
                if (Type == "Service")
                {
                    SqlParameter p1 = new SqlParameter("@Flag", "7");
                    SqlParameter p3 = new SqlParameter("@PujaID", PujaID);

                    dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", p1, p3);
                }
                if (Type == "Report")
                {
                    SqlParameter p1 = new SqlParameter("@Flag", "8");
                    SqlParameter p3 = new SqlParameter("@PujaID", PujaID);

                    dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", p1, p3);
                }

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
                        model.chatcharge = Convert.ToDouble(dt.Rows[i]["Price"].ToString());
                        model.callcharge = PujaID;
                        model.experience = dt.Rows[i]["Year_of_Experience"].ToString();
                        if(Type == "Puja")
                        {
                            model.type = "1";
                        }
                        if (Type == "Service")
                        {
                            model.type = "2";
                        }
                        if (Type == "Report")
                        {
                            model.type = "3";
                        }

                        SqlParameter p2 = new SqlParameter("@IDPandit", model.Panditid);
                        SqlParameter flag = new SqlParameter("@Flag", "11");
                        DataSet dtable = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_PanditRegistration", p2, flag);
                        if (dtable.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < dtable.Tables[0].Rows.Count; j++)
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

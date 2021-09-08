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
    public class DetailedReportManager
    {

        public List<DetailedReportModel> GetSpecialistsImagesWithName()
        {
            List<DetailedReportModel> List = new List<DetailedReportModel>();
            try
            {

                SqlParameter p1 = new SqlParameter("@Flag", "14");

                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", p1);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Price = string.Empty;
                        string listspecilization = string.Empty;
                        DetailedReportModel model = new DetailedReportModel();
                        model.Panditid = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        model.Panditname = dt.Rows[i]["Fullname"].ToString();
                        model.Image = (byte[])dt.Rows[i]["ProfileImage"];
                        model.experience = dt.Rows[i]["Year_of_Experience"].ToString();

                        SqlParameter p2 = new SqlParameter("@IDPandit", model.Panditid);
                        SqlParameter flag = new SqlParameter("@Flag", "15");
                        DataSet dtable = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_PanditRegistration", p2, flag);
                        if (dtable.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < dtable.Tables[0].Rows.Count; j++)
                            {
                                if (j == 0)
                                {
                                    Price = dtable.Tables[0].Rows[j]["Price"].ToString();
                                }

                            }
                            model.Price = Price;

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

 


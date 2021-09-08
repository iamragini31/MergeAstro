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
  public  class GetReportManager
    {
        public List<GetReportModel> GetReportsWithDetails()
        {
            List<GetReportModel> List = new List<GetReportModel>();
            try
            {
                SqlParameter flg = new SqlParameter("@Flag", "1");
                DataTable dt = new DataTable();
                dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Detailed_Reports",flg);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GetReportModel model = new GetReportModel();
                        model.Reportname = dt.Rows[i]["ReportName"].ToString();
                        //model.Price = dt.Rows[i]["price"].ToString();
                        model.Images = dt.Rows[i]["Images"].ToString();
                        model.Description = dt.Rows[i]["Description"].ToString();
                        model.ReportID = (long)dt.Rows[i]["ID"];
                        model.PartnerFlag = dt.Rows[i]["PartnerFlag"].ToString();

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

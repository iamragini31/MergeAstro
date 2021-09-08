using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using Pandit_ApplicationEntity;

namespace Pandit_ApplicationManager
{
   public class StartChatManager
    {
        public List<StartChatModel> FetchStatus()
        {
            List<StartChatModel> listStartChart = new List<StartChatModel>();
            try
            {
                // SqlParameter p1 = new SqlParameter("@ID", 1);
                SqlParameter flag = new SqlParameter("@flag", "13");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditOrderHistory", flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StartChatModel startchartmodel = new StartChatModel();
                        startchartmodel.Status = Convert.ToInt64(dt.Rows[i]["Status"].ToString());


                        listStartChart.Add(startchartmodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listStartChart;
        }
    }
}

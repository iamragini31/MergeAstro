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
    public class NewlyRegisteredPanditManager
    {
        public List<NewlyRegisteredPanditModel> Display()
        {
            List<NewlyRegisteredPanditModel> listNewlyRegisteredPanditModel = new List<NewlyRegisteredPanditModel>();
            try
            {
                // SqlParameter p1 = new SqlParameter("@ID", 1);
                SqlParameter flag = new SqlParameter("@flag", "9");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        NewlyRegisteredPanditModel newlyregisteredpanditmodel = new NewlyRegisteredPanditModel();
                        newlyregisteredpanditmodel.ID = dt.Rows[i]["Id"].ToString();
                        newlyregisteredpanditmodel.PanditID = dt.Rows[i]["PanditID"].ToString();
                        newlyregisteredpanditmodel.Fullname = dt.Rows[i]["Fullname"].ToString();
                        newlyregisteredpanditmodel.Date = dt.Rows[i]["RecievedDate"].ToString();

                        listNewlyRegisteredPanditModel.Add(newlyregisteredpanditmodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listNewlyRegisteredPanditModel;
        }
    }
}

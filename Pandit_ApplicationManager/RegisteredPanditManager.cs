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
   public class RegisteredPanditManager
    {
        public List<RegisteredPanditModel> Display()
        {
            List<RegisteredPanditModel> listregisteredpanditmodel = new List<RegisteredPanditModel>();
            try
            {
                // SqlParameter p1 = new SqlParameter("@ID", 1);
                SqlParameter flag = new SqlParameter("@flag", "16");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RegisteredPanditModel registeredpanditmodel = new RegisteredPanditModel();
                        registeredpanditmodel.ID = dt.Rows[i]["Id"].ToString();
                        registeredpanditmodel.PanditID = dt.Rows[i]["PanditID"].ToString();
                        registeredpanditmodel.Fullname = dt.Rows[i]["Fullname"].ToString();
                        registeredpanditmodel.Date = dt.Rows[i]["RecievedDate"].ToString();
                        registeredpanditmodel.DisplayName = dt.Rows[i]["DisplayName"].ToString();

                        listregisteredpanditmodel.Add(registeredpanditmodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listregisteredpanditmodel;
        }


    }
}

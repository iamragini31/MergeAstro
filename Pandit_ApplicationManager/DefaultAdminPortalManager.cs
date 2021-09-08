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
   public class DefaultAdminPortalManager
    {

        public DefaultAdminPortalModel Bindtab()
        {
            DefaultAdminPortalModel model = new DefaultAdminPortalModel();
            try
            {
                SqlParameter flag = new SqlParameter("@Flag", "13");
                DataSet ds = clsDataAccess.ExecuteDataset(CommandType.StoredProcedure, "Sp_PanditRegistration", flag);
                if(ds.Tables.Count > 0)
                {
                    model.Newpandit = Convert.ToInt64(ds.Tables[0].Rows[0]["Newpandit"]);
                    model.Acceptedpandit = Convert.ToInt64(ds.Tables[1].Rows[0]["Accepted"]);
                    model.Registeredpandit = Convert.ToInt64(ds.Tables[2].Rows[0]["Registered"]);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return model;
        }
    }
}

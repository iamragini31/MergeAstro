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
   public class VerifiedPanditManager
    {
        public List<VerifiedPanditModel> Display()
        {
            List<VerifiedPanditModel> listVerifiedPanditmodel = new List<VerifiedPanditModel>();
            try
            {
                // SqlParameter p1 = new SqlParameter("@ID", 1);
                SqlParameter flag = new SqlParameter("@flag", "17");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_PanditRegistration", flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        VerifiedPanditModel verifiedpanditmodel = new VerifiedPanditModel();
                        verifiedpanditmodel.ID = dt.Rows[i]["Id"].ToString();
                        verifiedpanditmodel.PanditID = dt.Rows[i]["PanditID"].ToString();
                        verifiedpanditmodel.Fullname = dt.Rows[i]["Fullname"].ToString();
                        verifiedpanditmodel.Date = dt.Rows[i]["RecievedDate"].ToString();

                        listVerifiedPanditmodel.Add(verifiedpanditmodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listVerifiedPanditmodel;
        }
    }
}

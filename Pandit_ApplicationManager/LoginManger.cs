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
    public class LoginManager
    {
        public List<LoginModel> LoginReDirect(string username, string password)
        {
            List<LoginModel> listLoginModel = new List<LoginModel>();

            try
            {
                SqlParameter p1 = new SqlParameter("@PanditID", username);
                SqlParameter p2 = new SqlParameter("@Password", password);
                SqlParameter flag = new SqlParameter("@flag", "1");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_LoginReDirect", flag, p1, p2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LoginModel loginmodel = new LoginModel();
                        loginmodel.ID = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        loginmodel.Status = dt.Rows[i]["Status"].ToString();
                        loginmodel.UserName = dt.Rows[i]["FullName"].ToString();
                        listLoginModel.Add(loginmodel);

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listLoginModel;


        }


    }
}

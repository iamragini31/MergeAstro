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
    public class PackagesManager
    {

        public List<PackagesModel> Bindpackages(int panditid)


        {
            List<PackagesModel> list = new List<PackagesModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@PanditID", panditid);
                SqlParameter flag1 = new SqlParameter("@flag", "2");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Package_Master", p1, flag1);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        PackagesModel packagesmodel = new PackagesModel();
                        packagesmodel.packageID = Convert.ToInt64(dt.Rows[i]["ID"]);
                        packagesmodel.PackageName = (dt.Rows[i]["PackageName"].ToString());
                        packagesmodel.packageprice = Convert.ToInt64(dt.Rows[i]["Price"]);
                        packagesmodel.packageDescription = (dt.Rows[i]["Description"].ToString());
                        list.Add(packagesmodel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<PackagesModel> BindPackagesForUpgrade()


        {
            List<PackagesModel> list = new List<PackagesModel>();
            try
            {
                SqlParameter flag = new SqlParameter("@Flag", '1');
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Package_Master", flag);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        PackagesModel packagesmodel = new PackagesModel();
                        packagesmodel.packageID = Convert.ToInt64(dt.Rows[i]["ID"]);
                        packagesmodel.PackageName = (dt.Rows[i]["PackageName"].ToString());
                        packagesmodel.packageprice = Convert.ToInt64(dt.Rows[i]["Price"]);
                        packagesmodel.packageDescription = (dt.Rows[i]["Description"].ToString());
                        list.Add(packagesmodel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}

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
    public class ServicesMasterManager
    {
        ServicesMasterModel servicemastermodel = new ServicesMasterModel();
        public int SaveService(ServicesMasterModel servicesmastermodel)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@Snum", servicesmastermodel.Snum);
            SqlParameter p2 = new SqlParameter("@Servicename", servicesmastermodel.ServiceName);
            SqlParameter p3 = new SqlParameter("@Price", servicesmastermodel.Price);
            SqlParameter p4 = new SqlParameter("@Description", servicesmastermodel.Description);
            SqlParameter p5 = new SqlParameter("@Status", servicesmastermodel.ChangeStatus);
            //SqlParameter p5 = new SqlParameter("@ServiceImage", servicesmastermodel.ServiceImage);
            SqlParameter p6 = new SqlParameter("@ServiceFileName", servicesmastermodel.ServiceImagePath);
            //SqlParameter p7 = new SqlParameter("@ServiceContentType", servicesmastermodel.ServiceImagecontent);

            SqlParameter flag = new SqlParameter("@Flag", "1");
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Insert_Service_Details", p1, p2, p3, p4,p5, p6, flag);


            return res;
        }

        public int UpdateService(ServicesMasterModel servicesmastermodel)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@Snum", servicesmastermodel.Snum);
            SqlParameter p2 = new SqlParameter("@Servicename", servicesmastermodel.ServiceName);
            SqlParameter p3 = new SqlParameter("@Price", servicesmastermodel.Price);
            SqlParameter p4 = new SqlParameter("@Description", servicesmastermodel.Description);
            //SqlParameter p5 = new SqlParameter("@ServiceImage", servicesmastermodel.ServiceImage);
            SqlParameter p6 = new SqlParameter("@ServiceFileName", servicesmastermodel.ServiceImagePath);
            //SqlParameter p7 = new SqlParameter("@ServiceContentType", servicesmastermodel.ServiceImagecontent);
            SqlParameter p8 = new SqlParameter("@ID", servicesmastermodel.ID);
            SqlParameter flag = new SqlParameter("@Flag", "2");
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Insert_Service_Details", p1, p2, p3, p4, p6, p8, flag);


            return res;
        }
        public List<ServicesMasterModel> DisplayService()
        {
            List<ServicesMasterModel> listServicesMasterModels = new List<ServicesMasterModel>();
            try
            {
                // SqlParameter p1 = new SqlParameter("@ID", 1);
                SqlParameter flag = new SqlParameter("@flag", "3");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_master", flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ServicesMasterModel Servicesmastermodel = new ServicesMasterModel();
                        Servicesmastermodel.Snum = dt.Rows[i]["Snum"].ToString();
                        Servicesmastermodel.ID = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        Servicesmastermodel.ServiceName = dt.Rows[i]["Servicename"].ToString();
                        Servicesmastermodel.Price = dt.Rows[i]["Price"].ToString();
                        Servicesmastermodel.ServiceImage = dt.Rows[i]["Images"].ToString();
                        Servicesmastermodel.Description = dt.Rows[i]["Description"].ToString();

                        listServicesMasterModels.Add(Servicesmastermodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listServicesMasterModels;
        }

        public List<ServicesMasterModel> DatabyId(long ID)
        {
            List<ServicesMasterModel> listPujaMasterModel = new List<ServicesMasterModel>();
            try
            {
                SqlParameter p1 = new SqlParameter("@ID", ID);
                SqlParameter flag = new SqlParameter("@flag", "4");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Services_master", flag, p1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ServicesMasterModel pujamastermodel = new ServicesMasterModel();
                        pujamastermodel.ID = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        pujamastermodel.Snum = dt.Rows[i]["Snum"].ToString();
                        pujamastermodel.ServiceName = dt.Rows[i]["Servicename"].ToString();
                        pujamastermodel.Price = dt.Rows[i]["Price"].ToString();
                        pujamastermodel.ServiceImage =dt.Rows[i]["Images"].ToString();
                        pujamastermodel.Description = dt.Rows[i]["Description"].ToString();
                        listPujaMasterModel.Add(pujamastermodel);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listPujaMasterModel;
        }
        public int DeletebyId(long ID)
        {
            List<ServicesMasterModel> listPujaMasterModel = new List<ServicesMasterModel>();
            int res;
            try
            {
                SqlParameter p1 = new SqlParameter("@ID", ID);
                SqlParameter flag = new SqlParameter("@Flag", "5");
                //DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", flag, p1);
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Services_master", flag, p1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}

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
  public  class PujaMaster
    {
        PujaModelMaster pujamastermodel = new PujaModelMaster();
        public int SavePuja(PujaModelMaster pujamastermodel)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@Snum", pujamastermodel.Snum);
            SqlParameter p2 = new SqlParameter("@Pujasname", pujamastermodel.PujaName);
            SqlParameter p3 = new SqlParameter("@Price", pujamastermodel.Price);
            SqlParameter p4 = new SqlParameter("@Description", pujamastermodel.Description);
            //SqlParameter p5 = new SqlParameter("@PujaImage", pujamastermodel.PujaImage);
            SqlParameter p5 = new SqlParameter("@Status", pujamastermodel.ChangeStatus);

            SqlParameter p6 = new SqlParameter("@PujaFileName", pujamastermodel.PujaFileName);
            //SqlParameter p7 = new SqlParameter("@PujaContentType", pujamastermodel.PujaContentType);

            SqlParameter flag = new SqlParameter("@Flag", "1");
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Insert_Puja_Details", p1, p2, p3, p4,p5, p6, flag);


            return res;
        }

        public int UpdatePuja(PujaModelMaster pujamastermodel)
        {
            int res = 0;
            SqlParameter p1 = new SqlParameter("@Snum", pujamastermodel.Snum);
            SqlParameter p2 = new SqlParameter("@Pujasname", pujamastermodel.PujaName);
            SqlParameter p3 = new SqlParameter("@Price", pujamastermodel.Price);
            SqlParameter p4 = new SqlParameter("@Description", pujamastermodel.Description);
            //SqlParameter p5 = new SqlParameter("@PujaImage", pujamastermodel.PujaImage);
            SqlParameter p6 = new SqlParameter("@PujaFileName", pujamastermodel.PujaFileName);
            SqlParameter p5 = new SqlParameter("@Status", pujamastermodel.ChangeStatus);

            //SqlParameter p7 = new SqlParameter("@PujaContentType", pujamastermodel.PujaContentType);
            SqlParameter p8 = new SqlParameter("@ID", pujamastermodel.ID);
            SqlParameter flag = new SqlParameter("@Flag", "3");
            res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Insert_Puja_Details", p1, p2, p3, p4,p5, p6, p8, flag);


            return res;
        }

        public List<PujaModelMaster> DisplayPujas()
        {
            List<PujaModelMaster> listPujaMasterModel = new List<PujaModelMaster>();
            try
            {
                // SqlParameter p1 = new SqlParameter("@ID", 1);
                SqlParameter flag = new SqlParameter("@flag", "5");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PujaModelMaster pujamastermodel = new PujaModelMaster();
                        pujamastermodel.ID = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        pujamastermodel.Snum1 = dt.Rows[i]["Snum"].ToString();
                        pujamastermodel.Pujasname1 = dt.Rows[i]["Pujasname"].ToString();
                        pujamastermodel.Price1 = dt.Rows[i]["Price"].ToString();
                        pujamastermodel.PujaFileName = dt.Rows[i]["Images"].ToString();
                        pujamastermodel.Description1 = dt.Rows[i]["Description"].ToString();
                        pujamastermodel.ChangeStatus = dt.Rows[i]["Status"].ToString();

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

        public List<PujaModelMaster> DatabyId(long ID)
        {
            List<PujaModelMaster> listPujaMasterModel = new List<PujaModelMaster>();
            try
            {
                SqlParameter p1 = new SqlParameter("@ID", ID);
                SqlParameter flag = new SqlParameter("@flag", "3");
                DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", flag, p1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PujaModelMaster pujamastermodel = new PujaModelMaster();
                        pujamastermodel.ID = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                        pujamastermodel.Snum1 = dt.Rows[i]["Snum"].ToString();
                        pujamastermodel.Pujasname1 = dt.Rows[i]["Pujasname"].ToString();
                        pujamastermodel.Price1 = dt.Rows[i]["Price"].ToString();
                        pujamastermodel.PujaFileName = dt.Rows[i]["Images"].ToString();
                        pujamastermodel.Description1 = dt.Rows[i]["Description"].ToString();
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
            List<PujaModelMaster> listPujaMasterModel = new List<PujaModelMaster>();
            int res;
            try
            {
                SqlParameter p1 = new SqlParameter("@ID", ID);
                SqlParameter flag = new SqlParameter("@flag", "4");
                //DataTable dt = clsDataAccess.ExecuteDataTable(CommandType.StoredProcedure, "Sp_Puja_master", flag, p1);
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Puja_master", flag, p1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }
    }
}

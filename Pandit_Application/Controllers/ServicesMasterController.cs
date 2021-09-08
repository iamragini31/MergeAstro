using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class ServicesMasterController : Controller
    {
        // GET: ServicesMaster
        ServicesMaster servicemastermanager = new ServicesMaster();
        ServicesMasterModel servicesMasterModel = new ServicesMasterModel();
        public ActionResult ServicesMaster()
        {
            var list = servicemastermanager.DisplayService();
            return View(list);

        }
        public ActionResult AdminServicesMaster()
        {
            var list = servicemastermanager.DisplayService();
            return View(list);

        }
        public JsonResult SaveService(FormCollection form)
        {


            servicesMasterModel.Snum = form["txtSnum"];
            servicesMasterModel.ServiceName = form["ServiceName"];
            servicesMasterModel.Price = form["Price"];
            servicesMasterModel.Description = form["Description"];
            servicesMasterModel.ChangeStatus = form["ChangeStatus"];

            //servicesmastermodel.ServiceImage = (byte[])Session["ServiceImage"];
            //servicesMasterModel.ServiceImagePath = (Session["ServiceImagePath"].ToString());
            servicesMasterModel.ServiceImagePath = form["file1"];
            //servicesmastermodel.ServiceImagecontent = (Session["ServiceImagecontent"].ToString());

            int result = servicemastermanager.SaveService(servicesMasterModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateService(FormCollection form)
        {
            //ServicesMasterModel servicesmastermodel = new ServicesMasterModel();

            servicesMasterModel.Snum = form["txtSnum"];
            servicesMasterModel.ServiceName = form["ServiceName"];
            servicesMasterModel.Price = form["Price"];
            servicesMasterModel.Description = form["Description"];
            servicesMasterModel.ID = Convert.ToInt64(form["Id"]);
            servicesMasterModel.ChangeStatus = form["ChangeStatus"];

            //servicesmastermodel.ServiceImage = (byte[])Session["ServiceImage"];
            //servicesMasterModel.ServiceImagePath = (Session["ServiceImagePath"].ToString());
            servicesMasterModel.ServiceImagePath = form["file1"];
            //servicesmastermodel.ServiceImagecontent = (Session["ServiceImagecontent"].ToString());

            int result = servicemastermanager.UpdateService(servicesMasterModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveFile(FormCollection form)
        {

            byte[] bytes;
            string fname = "";
            string CompImage = "";
            string filename = "";
            var res = 0;
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            CompImage = testfiles[testfiles.Length - 1];
                            CompImage = Path.GetExtension(CompImage);
                        }
                        else
                        {
                            fname = file.FileName;
                            filename = file.FileName;

                            CompImage = Path.GetExtension(fname);
                            filename = filename.Replace(CompImage, "");
                        }
                        string[] AllowExtension = { ".jpg", ".jpeg", ".png", ".pdf", ".docx" };
                        for (int j = 0; j < AllowExtension.Length; j++)
                        {
                            string ProfilePhoto = AllowExtension[j];
                            string FileAddress = Server.MapPath("~/FilesImages/" + filename + ProfilePhoto);
                            FileInfo fileInfo = new FileInfo(FileAddress);
                            if (fileInfo.Exists)
                            {
                                fileInfo.Delete();
                            }
                        }
                        fname = Path.Combine(Server.MapPath("~/FilesImages/"), filename + CompImage);
                        file.SaveAs(fname);
                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }

                        Session["ServiceImage"] = bytes;
                        Session["ServiceImagePath"] = Path.GetFileName(file.FileName);
                        Session["ServiceImagecontent"] = file.ContentType;

                    }

                }
                catch (Exception ex)
                {
                }
            }



            return Json(filename + CompImage, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DisplayService()
        {

            var list = servicemastermanager.DisplayService();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(long ID)
        {
            // long Res = 0;
            var list = servicemastermanager.DatabyId(ID);
            if (list.Count > 0)
            {
                servicesMasterModel = list[0];
            }
            return View(servicesMasterModel);
        }
        public ActionResult AdminServiceEdit(long ID)
        {
            // long Res = 0;
            var list = servicemastermanager.DatabyId(ID);
            if (list.Count > 0)
            {
                servicesMasterModel = list[0];
            }
            return View(servicesMasterModel);
        }

        public ActionResult DeletebyId(long ID)
        {
            var list = servicemastermanager.DeletebyId(ID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
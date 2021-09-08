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
    public class PujaMasterController : Controller
    {
        // GET: PujaMaster
        PujaMaster pujamastermanager = new PujaMaster();
        PujaModelMaster PujaMastermodel = new PujaModelMaster();
        public ActionResult PujaMaster()
        {
            var list = pujamastermanager.DisplayPujas();
            return View(list);

        }
        public ActionResult AdminPujaMaster()
        {
            var list = pujamastermanager.DisplayPujas();
            return View(list);

        }
        public JsonResult SavePuja(FormCollection form)
        {
            //PujaModelMaster pujamastermodel = new PujaModelMaster();

            PujaMastermodel.Snum = form["txtSnum"];
            PujaMastermodel.PujaName = form["PujaName"];
            PujaMastermodel.Price = form["Price"];
            PujaMastermodel.Description = form["Description"];
            PujaMastermodel.ChangeStatus = form["ChangeStatus"];

            //pujamastermodel.PujaImage = (byte[])Session["PujaImage"];
            PujaMastermodel.PujaFileName = form["file1"]/* (Session["PujaImagePath"].ToString())*/;
            //pujamastermodel.PujaContentType = (Session["PujaImagecontent"].ToString());

            int result = pujamastermanager.SavePuja(PujaMastermodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePuja(FormCollection form)
        {
            //PujaModelMaster pujamastermodel = new PujaModelMaster();
            PujaMastermodel.Snum = form["txtSnum"];
            PujaMastermodel.PujaName = form["PujaName"];
            PujaMastermodel.Price = form["Price"];
            PujaMastermodel.ID = Convert.ToInt64(form["ID"]);
            PujaMastermodel.Description = form["Description"];
            PujaMastermodel.ChangeStatus = form["ChangeStatus"];

            //pujamastermodel.PujaImage = (byte[])Session["PujaImage"];
            PujaMastermodel.PujaFileName =form["file1"];
            //pujamastermodel.PujaContentType = (Session["PujaImagecontent"].ToString());
            int result = pujamastermanager.UpdatePuja(PujaMastermodel);
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

                        //Session["PujaImage"] = bytes;
                        Session["PujaImagePath"] = Path.GetFileName(file.FileName);
                        //Session["PujaImagecontent"] = file.ContentType;

                    }

                }
                catch (Exception ex)
                {
                }
            }



            return Json(filename + CompImage, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DisplayPujas()
        {

            var list = pujamastermanager.DisplayPujas();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(long ID)
        {
            // long Res = 0;
            var list = pujamastermanager.DatabyId(ID);
            if (list.Count > 0)
            {
                PujaMastermodel = list[0];
            }
            return View(PujaMastermodel);
        }
        public ActionResult AdminEdit(long ID)
        {
            // long Res = 0;
            var list = pujamastermanager.DatabyId(ID);
            if (list.Count > 0)
            {
                PujaMastermodel = list[0];
            }
            return View(PujaMastermodel);
        }

        public ActionResult DeletebyId(long ID)
        {
            var list = pujamastermanager.DeletebyId(ID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
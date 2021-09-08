using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class RegPanditDetailsController : Controller
    {
        RegPanditDetailsModel regpanditdetailsmodel = new RegPanditDetailsModel();
        RegPanditDetailsManager regpanditdetailsmanger = new RegPanditDetailsManager();
        // GET: RegPanditDetails
        //public ActionResult RegPanditDetails()
        //{
        //    return View();
        //}

        public ActionResult RegPanditDetails(int Id = 1)
        {
            Session["PanditId"] = Id;
            string Bengali, English, urdu, Tamil, French, Spanish, German, Hindi, lang = "";
            List<RegPanditDetailsModel> listRegPanditDetailsModel = new List<RegPanditDetailsModel>();


            listRegPanditDetailsModel = regpanditdetailsmanger.DisplayProfile(Id);
            if (listRegPanditDetailsModel.Count > 0)
            {
                regpanditdetailsmodel.ID = listRegPanditDetailsModel[0].ID;
                regpanditdetailsmodel.Fullname = listRegPanditDetailsModel[0].Fullname;
                regpanditdetailsmodel.PhoneNumber = listRegPanditDetailsModel[0].PhoneNumber;
                regpanditdetailsmodel.EmailAddress = listRegPanditDetailsModel[0].EmailAddress;
                regpanditdetailsmodel.Gender = listRegPanditDetailsModel[0].Gender;
                regpanditdetailsmodel.DateofBirth = listRegPanditDetailsModel[0].DateofBirth;
                regpanditdetailsmodel.YearsOfExperience = listRegPanditDetailsModel[0].YearsOfExperience;
                regpanditdetailsmodel.Address = listRegPanditDetailsModel[0].Address;
                regpanditdetailsmodel.City = listRegPanditDetailsModel[0].City;
                regpanditdetailsmodel.State = listRegPanditDetailsModel[0].State;
                regpanditdetailsmodel.Country = listRegPanditDetailsModel[0].Country;
                regpanditdetailsmodel.Pin = listRegPanditDetailsModel[0].Pin;
                regpanditdetailsmodel.AboutSelf = listRegPanditDetailsModel[0].AboutSelf;

                regpanditdetailsmodel.ProfileImage = listRegPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;



                Bengali = listRegPanditDetailsModel[0].Bengali;
                English = listRegPanditDetailsModel[0].English;
                urdu = listRegPanditDetailsModel[0].urdu;
                Tamil = listRegPanditDetailsModel[0].Tamil;
                French = listRegPanditDetailsModel[0].French;
                Spanish = listRegPanditDetailsModel[0].Spanish;
                German = listRegPanditDetailsModel[0].German;
                Hindi = listRegPanditDetailsModel[0].Hindi;
                if (Bengali != "" && Bengali != null && Bengali != " ")
                {
                    lang += Bengali;
                }
                if (English != "" && English != null && English != " ")
                {
                    if (lang == "")
                    {
                        lang += English;

                    }
                    else
                    {
                        lang += "," + English;

                    }
                }
                if (urdu != "" && urdu != null && urdu != " ")
                {
                    if (lang == "")
                    {
                        lang += urdu;

                    }
                    else
                    {
                        lang += "," + urdu;

                    }
                }
                if (Tamil != "" && Tamil != null && Tamil != " ")
                {
                    if (lang == "")
                    {
                        lang += Tamil;

                    }
                    else
                    {
                        lang += "," + Tamil;

                    }
                }
                if (French != "" && French != null && French != " ")
                {
                    if (lang == "")
                    {
                        lang += French;

                    }
                    else
                    {
                        lang += "," + French;

                    }
                }
                if (Spanish != "" && Spanish != null && Spanish != " ")
                {
                    if (lang == "")
                    {
                        lang += Spanish;

                    }
                    else
                    {
                        lang += "," + Spanish;

                    }
                }
                if (German != "" && German != null && German != " ")
                {
                    if (lang == "")
                    {
                        lang += German;

                    }
                    else
                    {
                        lang += "," + German;

                    }
                }
                if (Hindi != "" && Hindi != null && Hindi != " ")
                {
                    if (lang == "")
                    {
                        lang += Hindi;

                    }
                    else
                    {
                        lang += "," + Hindi;

                    }
                }
                regpanditdetailsmodel.Languages = lang;
            }

            return View(regpanditdetailsmodel);
        }



        public ActionResult DisplayImage()
        {
            var list = regpanditdetailsmanger.DisplayProfile((int)Session["PanditId"]);
            var datares = list;
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(datares[0].ProfileImage));
            return Json(img, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GovernmentId()
        {
            var list = regpanditdetailsmanger.DisplayProfile((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Biodata()
        {
            var list = regpanditdetailsmanger.DisplayProfile((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public FileResult DownloadGovId(int? fileId)
        {

            var list = regpanditdetailsmanger.DisplayProfile(fileId);
            var datares = list;

            var G1 = datares[0].GovernmentId;
            var G2 = datares[0].GovernmentIdContentType;
            var G3 = datares[0].GovernmentIdFileName;

            return File(G1, G2, G3);
        }
        [HttpPost]
        public FileResult DownloadBioData(int? fileId1)
        {
            var list = regpanditdetailsmanger.DisplayProfile(fileId1);
            var datares = list;
            var B1 = datares[0].BioData2;
            var B2 = datares[0].BioDataContentType;
            var B3 = datares[0].BioDataFileName;

            return File(B1, B2, B3);
        }


        public ActionResult BindServices()
        {
            var list = regpanditdetailsmanger.BindServices((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BindPujas()
        {
            var list = regpanditdetailsmanger.BindPujas((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Bindreports()
        {
            var list = regpanditdetailsmanger.BindReports((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CallChat()
        {
            var list = regpanditdetailsmanger.CallChat((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
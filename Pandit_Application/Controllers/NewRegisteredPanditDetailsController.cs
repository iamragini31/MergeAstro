using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;


namespace Pandit_Application.Controllers
{
    public class NewRegisteredPanditDetailsController : Controller
    {
        NewRegisteredPanditDetailsManager newregisteredpanditdetailsmanager = new NewRegisteredPanditDetailsManager();
        NewRegisteredPanditDetailsModel newregisteredpanditdetailsmodel = new NewRegisteredPanditDetailsModel();
        // GET: NewRegisteredPanditDetails
        public ActionResult NewRegisteredPanditDetails(int Id)
        {
            Session["PanditId"] = Id;
            string Bengali, English, urdu, Tamil, French, Spanish, German, Hindi, lang = "";
            List<NewRegisteredPanditDetailsModel> listNewRegisteredPanditDetailsModel = new List<NewRegisteredPanditDetailsModel>();


            listNewRegisteredPanditDetailsModel = newregisteredpanditdetailsmanager.DisplayProfile(Id);
            if (listNewRegisteredPanditDetailsModel.Count > 0)
            {
                newregisteredpanditdetailsmodel.ID = listNewRegisteredPanditDetailsModel[0].ID;
                newregisteredpanditdetailsmodel.Fullname = listNewRegisteredPanditDetailsModel[0].Fullname;
                newregisteredpanditdetailsmodel.PhoneNumber = listNewRegisteredPanditDetailsModel[0].PhoneNumber;
                newregisteredpanditdetailsmodel.EmailAddress = listNewRegisteredPanditDetailsModel[0].EmailAddress;
                newregisteredpanditdetailsmodel.Gender = listNewRegisteredPanditDetailsModel[0].Gender;
                newregisteredpanditdetailsmodel.DateofBirth = listNewRegisteredPanditDetailsModel[0].DateofBirth;
                newregisteredpanditdetailsmodel.YearsOfExperience = listNewRegisteredPanditDetailsModel[0].YearsOfExperience;
                newregisteredpanditdetailsmodel.Address = listNewRegisteredPanditDetailsModel[0].Address;
                newregisteredpanditdetailsmodel.City = listNewRegisteredPanditDetailsModel[0].City;
                newregisteredpanditdetailsmodel.State = listNewRegisteredPanditDetailsModel[0].State;
                newregisteredpanditdetailsmodel.Country = listNewRegisteredPanditDetailsModel[0].Country;
                newregisteredpanditdetailsmodel.Pin = listNewRegisteredPanditDetailsModel[0].Pin;
                newregisteredpanditdetailsmodel.AboutSelf = listNewRegisteredPanditDetailsModel[0].AboutSelf;

                newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;



                Bengali = listNewRegisteredPanditDetailsModel[0].Bengali;
                English = listNewRegisteredPanditDetailsModel[0].English;
                urdu = listNewRegisteredPanditDetailsModel[0].urdu;
                Tamil = listNewRegisteredPanditDetailsModel[0].Tamil;
                French = listNewRegisteredPanditDetailsModel[0].French;
                Spanish = listNewRegisteredPanditDetailsModel[0].Spanish;
                German = listNewRegisteredPanditDetailsModel[0].German;
                Hindi = listNewRegisteredPanditDetailsModel[0].Hindi;
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
                newregisteredpanditdetailsmodel.Languages = lang;
            }

            return View(newregisteredpanditdetailsmodel);
        }


        public ActionResult AdminNewApplicantDetails(int Id=1)
        {
            Session["PanditId"] = Id;
            string Bengali, English, urdu, Tamil, French, Spanish, German, Hindi, lang = "";
            List<NewRegisteredPanditDetailsModel> listNewRegisteredPanditDetailsModel = new List<NewRegisteredPanditDetailsModel>();


            listNewRegisteredPanditDetailsModel = newregisteredpanditdetailsmanager.DisplayProfile(Id);
            if (listNewRegisteredPanditDetailsModel.Count > 0)
            {
                newregisteredpanditdetailsmodel.ID = listNewRegisteredPanditDetailsModel[0].ID;
                newregisteredpanditdetailsmodel.Fullname = listNewRegisteredPanditDetailsModel[0].Fullname;
                newregisteredpanditdetailsmodel.PhoneNumber = listNewRegisteredPanditDetailsModel[0].PhoneNumber;
                newregisteredpanditdetailsmodel.EmailAddress = listNewRegisteredPanditDetailsModel[0].EmailAddress;
                newregisteredpanditdetailsmodel.Gender = listNewRegisteredPanditDetailsModel[0].Gender;
                newregisteredpanditdetailsmodel.DateofBirth = listNewRegisteredPanditDetailsModel[0].DateofBirth;
                newregisteredpanditdetailsmodel.YearsOfExperience = listNewRegisteredPanditDetailsModel[0].YearsOfExperience;
                newregisteredpanditdetailsmodel.Address = listNewRegisteredPanditDetailsModel[0].Address;
                newregisteredpanditdetailsmodel.City = listNewRegisteredPanditDetailsModel[0].City;
                newregisteredpanditdetailsmodel.State = listNewRegisteredPanditDetailsModel[0].State;
                newregisteredpanditdetailsmodel.Country = listNewRegisteredPanditDetailsModel[0].Country;
                newregisteredpanditdetailsmodel.Pin = listNewRegisteredPanditDetailsModel[0].Pin;
                newregisteredpanditdetailsmodel.AboutSelf = listNewRegisteredPanditDetailsModel[0].AboutSelf;

                newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;



                Bengali = listNewRegisteredPanditDetailsModel[0].Bengali;
                English = listNewRegisteredPanditDetailsModel[0].English;
                urdu = listNewRegisteredPanditDetailsModel[0].urdu;
                Tamil = listNewRegisteredPanditDetailsModel[0].Tamil;
                French = listNewRegisteredPanditDetailsModel[0].French;
                Spanish = listNewRegisteredPanditDetailsModel[0].Spanish;
                German = listNewRegisteredPanditDetailsModel[0].German;
                Hindi = listNewRegisteredPanditDetailsModel[0].Hindi;
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
                newregisteredpanditdetailsmodel.Languages = lang;
            }

            return View(newregisteredpanditdetailsmodel);
        }

        public ActionResult VerifiedPanditDetails(int Id = 1)
        {
            Session["PanditId"] = Id;
            string Bengali, English, urdu, Tamil, French, Spanish, German, Hindi, lang = "";
            List<NewRegisteredPanditDetailsModel> listNewRegisteredPanditDetailsModel = new List<NewRegisteredPanditDetailsModel>();


            listNewRegisteredPanditDetailsModel = newregisteredpanditdetailsmanager.DisplayProfileVerfied(Id);
            if (listNewRegisteredPanditDetailsModel.Count > 0)
            {
                newregisteredpanditdetailsmodel.ID = listNewRegisteredPanditDetailsModel[0].ID;
                newregisteredpanditdetailsmodel.Fullname = listNewRegisteredPanditDetailsModel[0].Fullname;
                newregisteredpanditdetailsmodel.PhoneNumber = listNewRegisteredPanditDetailsModel[0].PhoneNumber;
                newregisteredpanditdetailsmodel.EmailAddress = listNewRegisteredPanditDetailsModel[0].EmailAddress;
                newregisteredpanditdetailsmodel.Gender = listNewRegisteredPanditDetailsModel[0].Gender;
                newregisteredpanditdetailsmodel.DateofBirth = listNewRegisteredPanditDetailsModel[0].DateofBirth;
                newregisteredpanditdetailsmodel.YearsOfExperience = listNewRegisteredPanditDetailsModel[0].YearsOfExperience;
                newregisteredpanditdetailsmodel.Address = listNewRegisteredPanditDetailsModel[0].Address;
                newregisteredpanditdetailsmodel.City = listNewRegisteredPanditDetailsModel[0].City;
                newregisteredpanditdetailsmodel.State = listNewRegisteredPanditDetailsModel[0].State;
                newregisteredpanditdetailsmodel.Country = listNewRegisteredPanditDetailsModel[0].Country;
                newregisteredpanditdetailsmodel.Pin = listNewRegisteredPanditDetailsModel[0].Pin;
                newregisteredpanditdetailsmodel.AboutSelf = listNewRegisteredPanditDetailsModel[0].AboutSelf;

                newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;

                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;
                //newregisteredpanditdetailsmodel.ProfileImage = listNewRegisteredPanditDetailsModel[0].ProfileImage;



                Bengali = listNewRegisteredPanditDetailsModel[0].Bengali;
                English = listNewRegisteredPanditDetailsModel[0].English;
                urdu = listNewRegisteredPanditDetailsModel[0].urdu;
                Tamil = listNewRegisteredPanditDetailsModel[0].Tamil;
                French = listNewRegisteredPanditDetailsModel[0].French;
                Spanish = listNewRegisteredPanditDetailsModel[0].Spanish;
                German = listNewRegisteredPanditDetailsModel[0].German;
                Hindi = listNewRegisteredPanditDetailsModel[0].Hindi;
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
                newregisteredpanditdetailsmodel.Languages = lang;
            }

            return View(newregisteredpanditdetailsmodel);
        }
        public ActionResult validateregister()
        {
            var list = newregisteredpanditdetailsmanager.ValidationDone((int)Session["PanditId"]);
            if (list > 0)
            {
                var res = newregisteredpanditdetailsmanager.GetPanditIDPASS(Convert.ToInt32(Session["PanditId"]));
                if (res.USerid != "")
                {
                    string To = res.EmailAddress;
                    string Subject = "Pandit Admin Login Credential";
                    string Message = "Please Login to Your Dashboard Uisng this Credential given Below:</br></br>" +
                        "UserID:" + res.USerid +
                        "</br>Password:" + res.Password + "" +
                        "</br>Link: <a href='pandit.erpcart.in'></a>";
                    Mails.SendMailforMeeting(To, Subject, Message);
                }

            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayImage()
        {
            var list = newregisteredpanditdetailsmanager.DisplayProfile((int)Session["PanditId"]);
            var datares = list;
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(datares[0].ProfileImage));
            return Json(img, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayImageVerified()
        {
            var list = newregisteredpanditdetailsmanager.DisplayProfileVerfied((int)Session["PanditId"]);
            var datares = list;
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(datares[0].ProfileImage));
            return Json(img, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GovernmentId()
        {
            var list = newregisteredpanditdetailsmanager.DisplayProfile((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GovernmentIdVerified()
        {
            var list = newregisteredpanditdetailsmanager.DisplayProfileVerfied((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Biodata()
        {
            var list = newregisteredpanditdetailsmanager.DisplayProfile((int)Session["PanditId"]);
            return Json(list, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public FileResult DownloadGovId(int? fileId)
        {

            var list = newregisteredpanditdetailsmanager.DisplayProfile(fileId);
            var datares = list;

            var G1 = datares[0].GovernmentId;
            var G2 = datares[0].GovernmentIdContentType;
            var G3 = datares[0].GovernmentIdFileName;

            return File(G1, G2, G3);
        }
        [HttpPost]
        public FileResult DownloadBioData(int? fileId1)
        {
            var list = newregisteredpanditdetailsmanager.DisplayProfile(fileId1);
            var datares = list;
            var B1 = datares[0].BioData2;
            var B2 = datares[0].BioDataContentType;
            var B3 = datares[0].BioDataFileName;

            return File(B1, B2, B3);
        }



    }
}
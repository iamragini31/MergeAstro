using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class ProfilePageController : Controller
    {
        ProfilePageManager profilePageManager = new ProfilePageManager();
        ProfilePageModel profilePageModel = new ProfilePageModel();

        // GET: ProfilePage
        public ActionResult ProfilePage()
        {
            string Bengali, English, urdu, Tamil, French, Spanish, German, Hindi, lang = "";
            List<ProfilePageModel> listProfilePageModel = new List<ProfilePageModel>();

            listProfilePageModel = profilePageManager.FetchPanditDetailsForProfile(Convert.ToInt32(Session["PanditID"]));
            if (listProfilePageModel.Count > 0)
            {
                profilePageModel.Fullname = listProfilePageModel[0].Fullname;
                profilePageModel.Gender = listProfilePageModel[0].Gender;
                profilePageModel.DateofBirth = listProfilePageModel[0].DateofBirth;
                profilePageModel.EmailAddress = listProfilePageModel[0].EmailAddress;
                profilePageModel.PhoneNumber = listProfilePageModel[0].PhoneNumber;
                profilePageModel.Address = listProfilePageModel[0].Address + "," + listProfilePageModel[0].City + "," + listProfilePageModel[0].State + "," + listProfilePageModel[0].Zip + "," + listProfilePageModel[0].Country;
                profilePageModel.City = listProfilePageModel[0].City;
                profilePageModel.State = listProfilePageModel[0].State;
                profilePageModel.Country = listProfilePageModel[0].Country;
                profilePageModel.Zip = listProfilePageModel[0].Zip;
                profilePageModel.YearsOfExperience = listProfilePageModel[0].YearsOfExperience;
                profilePageModel.ChargesForCallPerMinu = listProfilePageModel[0].ChargesForCallPerMinu;
                profilePageModel.ChargesForChatPerMinu = listProfilePageModel[0].ChargesForChatPerMinu;
                profilePageModel.PackageName = listProfilePageModel[0].PackageName;
                Bengali = listProfilePageModel[0].Bengali;
                English = listProfilePageModel[0].English;
                urdu = listProfilePageModel[0].urdu;
                Tamil = listProfilePageModel[0].Tamil;
                French = listProfilePageModel[0].French;
                Spanish = listProfilePageModel[0].Spanish;
                German = listProfilePageModel[0].German;
                Hindi = listProfilePageModel[0].Hindi;
                profilePageModel.TaxIdNumber = listProfilePageModel[0].TaxIdNumber;
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
                profilePageModel.Languages = lang;
                //+"," + listProfilePageModel[0].Price + "," + listProfilePageModel[0].Description
            }
            return View(profilePageModel);
        }

        public ActionResult PaymentOption()
        {

            var list = profilePageManager.PaymentOption(Convert.ToInt32(Session["PanditID"]));
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DisplayPuja()
        {
            var list = profilePageManager.DisplayPuja(Convert.ToInt32(Session["PanditID"]));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayServices()
        {
            var list = profilePageManager.DisplayServices(Convert.ToInt32(Session["PanditID"]));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
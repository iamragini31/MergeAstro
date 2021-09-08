using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class RegisterFormController : Controller
    {
        RegisterFormManager registerFormManger = new RegisterFormManager();
        RegisterFormModel registerFormModel = new RegisterFormModel();
        // GET: RegisterForm
        //test 
        public ActionResult RegisterForm(string data)
        {
            string Bengali, English, urdu, Tamil, French, Spanish, German, Hindi, lang = "";
            List<RegisterFormModel> listRegisterFormModel = new List<RegisterFormModel>();

            listRegisterFormModel = registerFormManger.FetchPanditDetails(Convert.ToInt32(Session["PanditID"]));
            if (listRegisterFormModel.Count > 0)
            {
                registerFormModel.Fullname = listRegisterFormModel[0].Fullname;
                registerFormModel.Gender = listRegisterFormModel[0].Gender;
                registerFormModel.DateofBirth = listRegisterFormModel[0].DateofBirth;
                registerFormModel.EmailAddress = listRegisterFormModel[0].EmailAddress;
                registerFormModel.PhoneNumber = listRegisterFormModel[0].PhoneNumber;
                registerFormModel.Address = listRegisterFormModel[0].Address;
                registerFormModel.City = listRegisterFormModel[0].City;
                registerFormModel.State = listRegisterFormModel[0].State;
                registerFormModel.Country = listRegisterFormModel[0].Country;
                registerFormModel.Zip = listRegisterFormModel[0].Zip;
                registerFormModel.YearsOfExperience = listRegisterFormModel[0].YearsOfExperience;
                Bengali = listRegisterFormModel[0].Bengali;
                English = listRegisterFormModel[0].English;
                urdu = listRegisterFormModel[0].urdu;
                Tamil = listRegisterFormModel[0].Tamil;
                French = listRegisterFormModel[0].French;
                Spanish = listRegisterFormModel[0].Spanish;
                German = listRegisterFormModel[0].German;
                Hindi = listRegisterFormModel[0].Hindi;
                if (Bengali != "" && Bengali != null)
                {
                    lang += Bengali;
                }
                if (English != "" && English != null)
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
                if (urdu != " " && urdu != null)
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
                if (Tamil != " " && Tamil != null)
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
                if (French != " " && French != null)
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
                if (Spanish != " " && Spanish != null)
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
                if (German != " " && German != null)
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
                if (Hindi != " " && Hindi != null)
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
                registerFormModel.Languages = lang;
                registerFormModel.PanditID = listRegisterFormModel[0].PanditID;
                Session["PanditID"] = listRegisterFormModel[0].PanditID;
            }
            return View(registerFormModel);
        }

        public ActionResult Setstatus(FormCollection form)
        {
            Session["TaxIdNumber"] = form["TaxIdNumber"]; ;
            Session["DisplayName"] = form["DisplayName"]; ;
            Session["OtherOrganisationDetails"] = form["OtherOrganisationDetails"]; ;
            int result = 0;
            string Palmistry, Kundli, Marriage_Specialist, Vastu, Business_Specialist, Career_Specialist, Spiritual_Healing_Specialist, Phychic_Reading_Specialist, Tarot, Vedic_Astrology,
            Gemology, KP_Astrology, Lal_Kitab_Astrology, Western_Astrology, Face_Reading, Signature_Reading, Vedic_Navgrah_Anusthan, Horary = "";
            string[] specialist = new string[18];
            Palmistry = form["Palmistry"]; Kundli = form["Kundli"]; Marriage_Specialist = form["Marriage_Specialist"]; Vastu = form["Vastu"];
            Business_Specialist = form["Business_Specialist"]; Career_Specialist = form["Career_Specialist"]; Spiritual_Healing_Specialist = form["Spiritual_Healing_Specialist"]; Phychic_Reading_Specialist = form["Phychic_Reading_Specialist"];
            Tarot = form["Tarot"]; Vedic_Astrology = form["Vedic_Astrology"]; Gemology = form["Gemology"]; KP_Astrology = form["KP_Astrology"]; Lal_Kitab_Astrology = form["Lal_Kitab_Astrology"]; Western_Astrology = form["Western_Astrology"];
            Face_Reading = form["Face_Reading"]; Signature_Reading = form["Signature_Reading"]; Vedic_Navgrah_Anusthan = form["Vedic_Navgrah_Anusthan"]; Horary = form["Horary"];
            if (Palmistry != "" && Palmistry != null && Palmistry != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Palmistry, Convert.ToInt32(Session["PanditID"]));
            }
            if (Kundli != "" && Kundli != null && Kundli != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Kundli, Convert.ToInt32(Session["PanditID"]));
            }
            if (Marriage_Specialist != "" && Marriage_Specialist != null && Marriage_Specialist != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Marriage_Specialist, Convert.ToInt32(Session["PanditID"]));
            }
            if (Vastu != "" && Vastu != null && Vastu != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Vastu, Convert.ToInt32(Session["PanditID"]));
            }
            if (Business_Specialist != "" && Business_Specialist != null && Business_Specialist != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Business_Specialist, Convert.ToInt32(Session["PanditID"]));
            }
            if (Career_Specialist != "" && Career_Specialist != null && Career_Specialist != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Career_Specialist, Convert.ToInt32(Session["PanditID"]));
            }
            if (Spiritual_Healing_Specialist != "" && Spiritual_Healing_Specialist != null && Spiritual_Healing_Specialist != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Spiritual_Healing_Specialist, Convert.ToInt32(Session["PanditID"]));
            }
            if (Phychic_Reading_Specialist != "" && Phychic_Reading_Specialist != null && Phychic_Reading_Specialist != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Phychic_Reading_Specialist, Convert.ToInt32(Session["PanditID"]));
            }
            if (Tarot != "" && Tarot != null && Tarot != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Tarot, Convert.ToInt32(Session["PanditID"]));
            }
            if (Vedic_Astrology != "" && Vedic_Astrology != null && Vedic_Astrology != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Vedic_Astrology, Convert.ToInt32(Session["PanditID"]));
            }
            if (Gemology != "" && Gemology != null && Gemology != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Gemology, Convert.ToInt32(Session["PanditID"]));
            }
            if (KP_Astrology != "" && KP_Astrology != null && KP_Astrology != "undefined")
            {
                result = registerFormManger.SaveSpecilization(KP_Astrology, Convert.ToInt32(Session["PanditID"]));
            }
            if (Lal_Kitab_Astrology != "" && Lal_Kitab_Astrology != null && Lal_Kitab_Astrology != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Lal_Kitab_Astrology, Convert.ToInt32(Session["PanditID"]));
            }
            if (Western_Astrology != "" && Western_Astrology != null && Western_Astrology != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Western_Astrology, Convert.ToInt32(Session["PanditID"]));
            }
            if (Face_Reading != "" && Face_Reading != null && Face_Reading != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Face_Reading, Convert.ToInt32(Session["PanditID"]));
            }
            if (Signature_Reading != "" && Signature_Reading != null && Signature_Reading != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Signature_Reading, Convert.ToInt32(Session["PanditID"]));
            }
            if (Horary != "" && Horary != null && Horary != "undefined")
            {
                result = registerFormManger.SaveSpecilization(Horary, Convert.ToInt32(Session["PanditID"]));
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveFile(FormCollection form)
        {
            string base64string = string.Empty;
            string fname = "";
            string CompImage = "";
            string filename = "";
            byte[] bytes;
            string[] arr = new string[3];
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }

                        Session["TaxIDImage"] = bytes;
                        Session["TaxIDImagePath"] = Path.GetFileName(file.FileName);
                        Session["TaxIDImagecontent"] = file.ContentType;

                    }

                }
                catch (Exception ex)
                {
                }
            }
            return Json(arr, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSecialisation()
        {
            var list = registerFormManger.GetSpecialization(Convert.ToInt32(Session["PanditID"]));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
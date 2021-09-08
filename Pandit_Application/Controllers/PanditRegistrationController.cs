using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;



using System.Text;

namespace Pandit_Application.Controllers
{
    public class PanditRegistrationController : Controller
    {
        // GET: PunditRegForm
        PunditRegFormModel Panditmodel = new PunditRegFormModel();
        NewRegisteredPanditDetailsManager newregisteredpanditdetailsmanager = new NewRegisteredPanditDetailsManager();
        PunditRegFormManager punditregformmanager = new PunditRegFormManager();
        public ActionResult PanditRegistration()
        {
            Session["ProfileImage"] = "";
            Session["ProfileImagePath"] = "";
            Session["ProfileImageContent"] = "";
            Session["GovernmentId"] = "";
            Session["GovernmentIdPath"] = "";
            Session["GovernmentIdContent"] = "";
            Session["BioData2"] = "";
            Session["BioDataPath"] = "";
            Session["BioDataPathContent"] = "";
            return View();
        }


        //public ActionResult PanditRegistration(FormCollection form)
        //{
        //    return View();
        //}
        public ActionResult GetSkill()

        {
            var list = punditregformmanager.GetAllSkills();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSpecialization()
        {
            var list = punditregformmanager.GetAllSpecialization();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RegistrationPandit(FormCollection form)
        {

            // StudentRegistrationmodel.StudentRegID=Convert.ToInt64(form["StudentRegID"]);
            Panditmodel.Fullname = form["Fullname"];
            Panditmodel.Countrycode = form["countrycode"];

            Panditmodel.Mobile = Convert.ToInt64(form["Mobile"]);
            Panditmodel.Email = form["Email"];
            Panditmodel.Gender = (form["gender"]);
            Panditmodel.DOB = (form["Day"]);
            Panditmodel.Month = form["Month"];
            Panditmodel.Year = (form["year"]);
            Panditmodel.YearsofExperience = (form["YearofExperience"]);
            Panditmodel.Address = form["Address"];
            Panditmodel.City = form["City"];
            Panditmodel.State = form["State"];
            Panditmodel.Country = (form["Country"]);
            Panditmodel.Zip = form["Zip"];
            Panditmodel.Hindi = (form["hindi"]);
            Panditmodel.English = (form["english"]);
            Panditmodel.Spanish = (form["spanish"]);
            Panditmodel.German = form["german"];
            Panditmodel.French = form["french"];
            Panditmodel.Tamil = (form["tamil"]);
            Panditmodel.Bengali = (form["bengali"]);
            Panditmodel.Urdu = form["urdu"];
            Panditmodel.files = form["file1filename"];
            Panditmodel.files1 = form["file2filename"];
            Panditmodel.files2 = form["file1filename"] /*form["file3filename"]*/;
            Panditmodel.AboutSelf = (form["aboutself"]);
            //added by pooja 


            Panditmodel.imageSrc = form["file1filename"];
            Panditmodel.imageSrc1 = form["file2filename"];
            Panditmodel.imageSrc2 = form["file1filename"] /*form["file3filename"]*/;


            //ADD BY MAHTAB
            //Panditmodel.ProfileImage =  Encoding.ASCII.GetBytes(form["files"]); ;
            Panditmodel.ProfileImage = Convert.FromBase64String(form["files"]);
            Panditmodel.ProfileImagePath = form["file1filename"];
            Panditmodel.ProfileImageContent = form["file1content"];

            Panditmodel.GovernmentId = Convert.FromBase64String(form["files1"]);
            Panditmodel.GovernmentIdPath = form["file2filename"];
            Panditmodel.GovernmentIdContent = form["file2content"];

            Panditmodel.BioData2 = Convert.FromBase64String(form["files"]/*form["files2"]*/);
            Panditmodel.BioDataPath = form["file1filename"]/*form["file3filename"]*/;
            Panditmodel.BioDataPathContent = form["file1content"] /*form["file3content"]*/;

            int panditid = punditregformmanager.SavePandit(Panditmodel);
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
                result = punditregformmanager.SaveSpecilization(Palmistry, panditid);
            }
            if (Kundli != "" && Kundli != null && Kundli != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Kundli, panditid);
            }
            if (Marriage_Specialist != "" && Marriage_Specialist != null && Marriage_Specialist != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Marriage_Specialist, panditid);
            }
            if (Vastu != "" && Vastu != null && Vastu != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Vastu, panditid);
            }
            if (Business_Specialist != "" && Business_Specialist != null && Business_Specialist != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Business_Specialist, panditid);
            }
            if (Career_Specialist != "" && Career_Specialist != null && Career_Specialist != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Career_Specialist, panditid);
            }
            if (Spiritual_Healing_Specialist != "" && Spiritual_Healing_Specialist != null && Spiritual_Healing_Specialist != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Spiritual_Healing_Specialist, panditid);
            }
            if (Phychic_Reading_Specialist != "" && Phychic_Reading_Specialist != null && Phychic_Reading_Specialist != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Phychic_Reading_Specialist, panditid);
            }
            if (Tarot != "" && Tarot != null && Tarot != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Tarot, panditid);
            }
            if (Vedic_Astrology != "" && Vedic_Astrology != null && Vedic_Astrology != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Vedic_Astrology, panditid);
            }
            if (Gemology != "" && Gemology != null && Gemology != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Gemology, panditid);
            }
            if (KP_Astrology != "" && KP_Astrology != null && KP_Astrology != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(KP_Astrology, panditid);
            }
            if (Lal_Kitab_Astrology != "" && Lal_Kitab_Astrology != null && Lal_Kitab_Astrology != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Lal_Kitab_Astrology, panditid);
            }
            if (Western_Astrology != "" && Western_Astrology != null && Western_Astrology != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Western_Astrology, panditid);
            }
            if (Face_Reading != "" && Face_Reading != null && Face_Reading != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Face_Reading, panditid);
            }
            if (Signature_Reading != "" && Signature_Reading != null && Signature_Reading != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Signature_Reading, panditid);
            }
            if (Horary != "" && Horary != null && Horary != "undefined")
            {
                result = punditregformmanager.SaveSpecilization(Horary, panditid);
            }
            if (result > 0)
            {
                var res = newregisteredpanditdetailsmanager.GetPanditIDPASS(Convert.ToInt32(panditid));
                if (res.USerid != "")
                {
                    string To = res.EmailAddress;
                    string Subject = "Newly Registered Specialist";
                    string Message = "Please Login to Your Dashboard as a new Pandit has Registred :</br></br>" +
                        "Pandit ID:" + res.USerid +
                        "</br>" +
                        "</br>Link: <a href='Astrohouz.erpcart.in/DefaultAdminPortal/DefaultAdminPortal'>Click</a>";
                    Mails.SendMailforMeeting(To, Subject, Message);
                }
            }
            string DOB = Panditmodel.DOB;
            return Json(panditid, JsonRequestBehavior.AllowGet);
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

                        // for Profile Image
                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }
                        base64string = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                        arr[0] = Convert.ToBase64String(bytes);
                        arr[1] = Path.GetFileName(file.FileName);
                        arr[2] = file.ContentType;
                        
                    }

                }
                catch (Exception ex)
                {
                }
            }
            return Json(arr, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveFileProfileImage(FormCollection form)
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

                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }

                        Session["ProfileImage"] = bytes;
                        Session["ProfileImagePath"] = Path.GetFileName(file.FileName);
                        Session["ProfileImagecontent"] = file.ContentType;

                    }

                }
                catch (Exception ex)
                {
                }
            }



            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveFileGovernmentId(FormCollection form)
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

                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }



                        Session["GovernmentId"] = bytes;
                        Session["GovernmentIdPath"] = Path.GetFileName(file.FileName);
                        Session["GovernmentIdContent"] = file.ContentType;

                    }

                }
                catch (Exception ex)
                {
                }
            }



            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveFileBioData(FormCollection form)
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

                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }


                        Session["BioData2"] = bytes;
                        Session["BioDataPath"] = Path.GetFileName(file.FileName);
                        Session["BioDataPathContent"] = file.ContentType;






                    }

                }
                catch (Exception ex)
                {
                }
            }



            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Checkemail(string emailAddress)
        {
            bool chk = false;
             chk = IsValidEmailAddress(emailAddress);
            return Json(chk, JsonRequestBehavior.AllowGet);
        }
        private static bool IsValidEmailAddress(string emailAddress)
        {
            return new System.ComponentModel.DataAnnotations
                                .EmailAddressAttribute()
                                .IsValid(emailAddress);
        }
    }
}
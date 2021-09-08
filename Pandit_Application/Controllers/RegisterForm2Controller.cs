using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class RegisterForm2Controller : Controller
    {
        RegisterForm2Manager registerformmanager = new RegisterForm2Manager();
        RegisterForm2Model registerform2model = new RegisterForm2Model();

        // GET: RegisterForm2
        public ActionResult RegisterForm2()
        {
            if ((Session["PanditID"]).ToString() == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }

        }

        public ActionResult GetServices()
        {
            var list = registerformmanager.GetAllSkills();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveSkill(string servicename, string servicesprice,string servicespriceINR)
        {
            int res = registerformmanager.SavePanditskill(servicename, servicesprice, servicespriceINR, Convert.ToInt32(Session["PanditID"]));
            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetPuja()
        {
            var list = registerformmanager.GetAllPuja();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SavePuja(string pujaname, string pujaprice,string pujapriceINR)
        {
            int res = registerformmanager.SavePanditPuja(pujaname, pujaprice, pujapriceINR, Convert.ToInt32(Session["PanditID"]));
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BindPackages()
        {
            var list = registerformmanager.Bindpackages();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SavePayment(FormCollection form)
        {
            long accountno = 0;
            var accno = form["AccNumber"];
            if (accno == "undefined" || accno == null || accno == "")
            {
                accountno = 0;
            }
            else
            {
                accountno = Convert.ToInt64(form["AccNumber"]);
            }
            registerform2model.BankName = form["BankName"];
            registerform2model.AccNumber = Convert.ToInt64(accountno);
            registerform2model.AccHolderName = form["AccHolderName"];
            registerform2model.IFSCCode = form["IFSCCode"];
            registerform2model.RoutingNum = form["RoutingNum"];
            registerform2model.Email_Bank = form["Email_Bank"];
            registerform2model.packageID = Convert.ToInt64(form["packageid"]);
            registerform2model.ChargesForCall = form["ChargesForCall"];
            registerform2model.ChargesForCallINR = form["ChargesForCallINR"];
            registerform2model.ChargesForChat = form["ChargesForChat"];
            registerform2model.ChargesForChatINR = form["ChargesForChatINR"];
            registerform2model.Paymentoption = form["paymentoption"];
            registerform2model.EmailZelle = form["EmailZelle"];
            registerform2model.PhoneNumberZelle = Convert.ToInt64(form["PhoneNumberZelle"]);
            registerform2model.PaypalAccountNumber = form["PaypalAccountNumber"];
            registerform2model.Email_Paypal = form["Email_Paypal"];
            registerform2model.GooglePayId = form["GooglePayId"];

           // Added By Mah

            registerform2model.TaxIDImage = (byte[])Session["TaxIDImage"];
            registerform2model.TaxIDImagePath = Session["TaxIDImagePath"].ToString();
            registerform2model.TaxIDImagecontent = Session["TaxIDImagecontent"].ToString();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string key = "rzp_test_VHYsyKNbvgMtmI";
            string secret = "daDylVSnXrdx9bfiyUi0QCcx";
            //RazorpayClient client = new RazorpayClient(key, secret);
            //Dictionary<string, object> options = new Dictionary<string, object>();
            //options.Add("amount", 50000); // amount in the smallest currency unit
            //options.Add("receipt", "TR0001");
            //options.Add("currency", "INR");
            //Order order = client.Order.Create(options);
            //Payment payment = new Payment();
            //payment.Capture(options);
            int res = registerformmanager.Submitpayment(registerform2model, Convert.ToInt32(Session["PanditID"]), Session["TaxIdNumber"].ToString(), Session["DisplayName"].ToString(), Session["OtherOrganisationDetails"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetDetailReport()
        {
            var list = registerformmanager.GetDetailReport();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveRaports(string postdata, String ReportCharges,string ReportChargesINR)
        {
            //DataTable val = registerformmanager.SaveReports((DataTable)JsonConvert.DeserializeObject(postdata, (typeof(DataTable))));


            //return Json(0, JsonRequestBehavior.AllowGet);
            DataTable dt = ((DataTable)JsonConvert.DeserializeObject(postdata, (typeof(DataTable))));

            var res = registerformmanager.SaveReports(dt, ReportCharges, Convert.ToInt64(Session["PanditID"]));
            return Json(0, JsonRequestBehavior.AllowGet);



        }
    }
}
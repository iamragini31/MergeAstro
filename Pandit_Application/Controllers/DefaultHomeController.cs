using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Types;


using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class DefaultHomeController : Controller
    {
        // GET: DefaultHome
        DefaultModel defaultmodel = new DefaultModel();
        DefaultManager defaultmanager = new DefaultManager();
        // GET: Default
        public ActionResult Default()
        {
            ViewBag.Name = Session["FullName"];
            ViewBag.UserId = Session["CustomerID"];
            Mails mail = new Mails();
            mail.Mailoutlook();
            //Session["CustomerID"] = null;
            // var call = GetCall();
            // const string accountSid = "AC11082ad28e8d4a072bcd8233e97786bc";
            // const string authToken = "258be23fca4a9c7a1f484eb6593356d7";
            // TwilioClient.Init(accountSid, authToken);
            // var message = MessageResource.Create(
            //body: "HII!",
            //from: new Twilio.Types.PhoneNumber("+17088310820"),
            //to: new Twilio.Types.PhoneNumber("+917209860586")
            //     );

            //Session["Wallet"] = 0;
            // var print = message.Sid;
            return View();
        }

        //public string GetCall()
        //{
        //    const string accountSid = "AC11082ad28e8d4a072bcd8233e97786bc";
        //    const string authToken = "258be23fca4a9c7a1f484eb6593356d7";
        //    TwilioClient.Init(accountSid, authToken);

        //    var to = new PhoneNumber("+917209860586");
        //    var from = new PhoneNumber("+17088310820");
        //    var call = CallResource.Create(to, from,
        //        url: new Uri("http://demo.twilio.com/docs/voice.xml"));

        //    return call.Sid;
        //}


        public ActionResult SaveCustomer(FormCollection form)
        {
            int res = defaultmanager.saveCustomer(form["CustomerFullname"], form["password"], form["Email"]); ;

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult validateLogin(FormCollection form)
        {
            int id = 0;
            var res = defaultmanager.Validateuser(form["loginid"], form["loginpassword"]);
            if (res.email == "" || res.email == null)
            {
                id = res.CustomerID;
            }
            else
            {
                Session["CustomerID"] = res.CustomerID;
                id = res.CustomerID;
                Session["FullName"] = res.FullName;
              
                    var Walletamt = defaultmanager.GetWalletamount(res.CustomerID);
                    Session["Wallet"] = Walletamt;
                
            }

            return Json(res, JsonRequestBehavior.AllowGet);

        }
        public ActionResult logout()
        {
            Session["CustomerID"] = null;

            Session["FullName"] = null;
            Session["Wallet"] = 0;
            int value = 1;
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getamt()
        {
            var Walletamt = defaultmanager.GetWalletamount(Convert.ToInt64(Session["CustomerID"]));
            Session["Wallet"] = Walletamt;
            return Json(Walletamt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveCustomerGmail(string email, string name)
        {
            int res = defaultmanager.saveCustomerGmail(name,  email); ;

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GoogleLogin(string email,string name)
        {
            int id = 0;
            var res = defaultmanager.Validateusergmail(email);
            if (res.email == "" || res.email == null)
            {
                id = res.CustomerID;
            }
            else
            {
                Session["CustomerID"] = res.CustomerID;
                id = res.CustomerID;
                Session["FullName"] = res.FullName;

                var Walletamt = defaultmanager.GetWalletamount(res.CustomerID);
                Session["Wallet"] = Walletamt;

            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class SelectedPujaController : Controller
    {
        // GET: SelectedPuja
        SelectedPujaManager selectedmanager = new SelectedPujaManager();
        public ActionResult SelectedPuja(long ID,string Servicename,int panditID)
        {
            Session["PujaID"] = ID;
            Session["Servicename"] = Servicename;
            Session["ServicePanditID"] = panditID;
            return View();
        }
         
        public ActionResult InsertSelectedPuja(FormCollection form)
        {
            SelectedPujaModel Panditmodel = new SelectedPujaModel();
            

            Panditmodel.name = form["name"];
            Panditmodel.Gender = form["gender"];
            Panditmodel.ServiceID = Convert.ToInt64(Session["PujaID"]);
            Panditmodel.Servicename = Session["Servicename"].ToString() ;
            string mo = form["Mobile"];
            Panditmodel.Addressid = form["addressid"];
            Panditmodel.Mobile = Convert.ToInt64(form["Mobile"]);
            Panditmodel.Email = form["Email"];
            Panditmodel.Gender = (form["gender"]);
            Panditmodel.day = (form["day"]);
            Panditmodel.Month = form["Month"];
            Panditmodel.Year = (form["year"]);
            Panditmodel.Martial_Status = (form["Martial_Status"]);
            //Panditmodel.Address = form["Address"];
            Panditmodel.TimeOfBirth = form["TimeOfBirth"];
            Panditmodel.CityOfBirth = form["txtcityofbirth"];
            Panditmodel.StateofBirth = form["txtstateofbirth"];
            Panditmodel.CountryofBirth = form["txtcountryofbirth"];




            var Dob = form["Month"] + "/" + (form["day"]) + "/" + form["year"];
            Panditmodel.DOB = Dob;
            Panditmodel.CountryCode = form["CountryCode"];
            Panditmodel.Occupation = form["Occupation"];
            Panditmodel.PreferredLang = form["PreferredLang"];
            Panditmodel.Address = form["Address"];
            Panditmodel.City = form["txtcity"];
            Panditmodel.State = form["State"];
            Panditmodel.Country = form["Country"];
            Panditmodel.Zip = form["txtZip"];



            Panditmodel.PanditID = Convert.ToInt64(Session["ServicePanditID"]);
            Panditmodel.TopicforCall = form["TopicforCall"];
            Panditmodel.CustomerID = Convert.ToInt64(Session["CustomerID"]);
            Panditmodel.Comment = form["TopicforCall"];
            Panditmodel.PanditID = Convert.ToInt64(Session["ServicePanditID"]);
            var res = selectedmanager.SavePujaBookingDetails(Panditmodel);
            var result = selectedmanager.GetServicesAmount(Convert.ToInt64(Session["PujaID"]), Session["Servicename"].ToString(), Convert.ToInt32(Session["ServicePanditID"]));
            //var amt = result.amount;
            //Session["Amountforpay"] = result.amount;
            //Session["Productnameforpay"] = result.Servicename;
            //Session["BackURL"] = "/DefaultHome/Default";
            var amt = result.amount;
            Session["Amountforpay"] = result.amount;
            var a = result.amount;
            var Gst = 0.18 * a;
            Session["gstamt"] = Gst;
            var pay_amt = 0.18 * a + a;
            Session["Payableamt"] = pay_amt;
            Session["Productnameforpay"] = result.Servicename;
            Session["BackURL"] = "/DefaultHome/Default";
            return Json(amt, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Bindaddress()
        {
            var res = selectedmanager.Bindaddress(Convert.ToInt64(Session["CustomerID"]));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
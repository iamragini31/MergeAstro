using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class CallIntakeFormController : Controller
    {
        CallIntakeFormManager callintakemanager = new CallIntakeFormManager();
        CallIntakeFormModel callintakemodel = new CallIntakeFormModel();
        // GET: CallIntakeForm
        public ActionResult CallIntakeForm( long PanditId, string Service)
        {
            Session["PanditidAgainstspecilizationbooked"] = PanditId;
            Session["Service"] = Service;
            return View();
        }

        public ActionResult SaveChat_Call_Service(FormCollection form)

        {
            int Sepecilistid = Convert.ToInt32(Session["SpecilizationId"]);
            int panditid = Convert.ToInt32(Session["PanditidAgainstspecilizationbooked"]);
            int custid = Convert.ToInt32(Session["CustomerID"]);
            CallIntakeFormModel callIntakeFormModel = new CallIntakeFormModel();
            callIntakeFormModel.Addressid = form["addressid"];
            callIntakeFormModel.name = form["name"];
            string mo = form["Mobile"];
            callIntakeFormModel.Mobile = Convert.ToInt64(form["Mobile"]);
            callIntakeFormModel.Email = form["Email"];
            callIntakeFormModel.gender = (form["gender"]);
            
            //callIntakeFormModel.Year = (form["year"]);
            callIntakeFormModel.Martial_Status = (form["Martial_Status"]);


            callIntakeFormModel.TimeOfBirth = form["TimeOfBirth"];
         
            callIntakeFormModel.City = form["txtcity"];
            callIntakeFormModel.Country = form["Country"];
            callIntakeFormModel.State = form["State"];
            
            callIntakeFormModel.Zip = form["txtZip"];
            callIntakeFormModel.Address = form["txtAddress"];

            
            callIntakeFormModel.Occupation = form["txtOccupation"];
            callIntakeFormModel.CityOfBirth = form["txtcityofbirth"];
            callIntakeFormModel.StateofBirth = form["txtstateofbirth"];
            callIntakeFormModel.CountryofBirth = form["txtcountryofbirth"];
           

            var Dob = form["Month"] + "/" + (form["day"]) + "/" + form["year"];
            callIntakeFormModel.DOB = Dob;
            callIntakeFormModel.CountryCode = form["CountryCode"];

            callIntakeFormModel.PreferredLang = form["PreferredLang"];

            callIntakeFormModel.CustomerID = Convert.ToInt64(Session["CustomerID"]);
            callIntakeFormModel.TopicforCall = form["TopicforCall"];
            callIntakeFormModel.Service = Session["Service"].ToString();
            var res = callintakemanager.SaveCall_Chat(callIntakeFormModel, Sepecilistid, panditid, custid);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Bindaddress()
        {
            var res = callintakemanager.Bindaddress(Convert.ToInt64(Session["CustomerID"]));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
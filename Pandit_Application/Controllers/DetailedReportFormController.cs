using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class DetailedReportFormController : Controller
    {
        DetailedReportFormManager detailedreportformmanager = new DetailedReportFormManager();
        DetailedReportFormModel detailedreportformmodel = new DetailedReportFormModel();
        // GET: DetailedReportForm
        public ActionResult DetailedReportForm(long ID, string Servicename, int panditID)
        {
            Session["ReportID"] = ID;
            Session["Servicename"] = Servicename;
            Session["PanditID"] = panditID;
            return View();
        }


        public ActionResult SaveDetailedReportForm(FormCollection form)

        {
            //int ReportID = Convert.ToInt32(Session["PanditIdReport"]);
            //int panditid = Convert.ToInt32(Session["PanditidAgainstspecilizationbooked"]);
            //int custid = Convert.ToInt32(Session["CustomerID"]);

            detailedreportformmodel.Addressid = form["addressid"];
            detailedreportformmodel.name = form["name"];
            string mo = form["Mobile"];
            detailedreportformmodel.Mobile = Convert.ToInt64(form["Mobile"]);
            detailedreportformmodel.Email = form["Email"];
            detailedreportformmodel.gender = (form["gender"]);

            //callIntakeFormModel.Year = (form["year"]);
            detailedreportformmodel.Martial_Status = (form["Martial_Status"]);


            detailedreportformmodel.TimeOfBirth = form["TimeOfBirth"];

            detailedreportformmodel.City = form["txtcity"];
            detailedreportformmodel.Country = form["Country"];
            detailedreportformmodel.State = form["State"];

            detailedreportformmodel.Zip = form["txtZip"];
            detailedreportformmodel.Address = form["txtAddress"];


            detailedreportformmodel.Occupation = form["txtOccupation"];
            detailedreportformmodel.CityOfBirth = form["txtcityofbirth"];
            detailedreportformmodel.StateofBirth = form["txtstateofbirth"];
            detailedreportformmodel.CountryofBirth = form["txtcountryofbirth"];


            var Dob = form["Month"] + "/" + (form["day"]) + "/" + form["year"];
            detailedreportformmodel.DOB = Dob;
            detailedreportformmodel.CountryCode = form["CountryCode"];

            detailedreportformmodel.PreferredLang = form["PreferredLang"];
            detailedreportformmodel.PanditID = Convert.ToInt64(Session["PanditID"]);
            detailedreportformmodel.ReportID = Convert.ToInt64(Session["ReportID"]);
            detailedreportformmodel.Servicename = Session["Servicename"].ToString();

            detailedreportformmodel.CustomerID = Convert.ToInt64(Session["CustomerID"]);
            detailedreportformmodel.TopicforCall = form["TopicforCall"];

            //for Partner details
            detailedreportformmodel.Ptrtxtname = form["Ptrtxtname"];
            detailedreportformmodel.Ptrddlgender = form["Ptrddlgender"];
            detailedreportformmodel.PtrddlMartial_Status = form["PtrddlMartial_Status"];
            var PtrDob = form["Ptrddlmonth"] + "/" + (form["Ptrddlday"]) + "/" + form["Ptrddlyear"];
            detailedreportformmodel.PtrDOB = PtrDob;
            detailedreportformmodel.PtrtxtTimeOfBirth = form["PtrtxtTimeOfBirth"];
            detailedreportformmodel.Ptrtxtcityofbirth = form["Ptrtxtcityofbirth"];
            detailedreportformmodel.PtrtxtstateofBirth = form["PtrtxtstateofBirth"];
            detailedreportformmodel.Ptrtxtcountryofbirth = form["Ptrtxtcountryofbirth"];
            detailedreportformmodel.PtrtxtAddress = form["PtrtxtAddress"];
            detailedreportformmodel.Ptrtxtcity = form["Ptrtxtcity"];
            detailedreportformmodel.Ptrtxtstate = form["Ptrtxtstate"];
            detailedreportformmodel.PtrtxtCountry = form["PtrtxtCountry"];
            detailedreportformmodel.PtrtxtZip = form["PtrtxtZip"];









            //detailedreportformmodel.Detailedreport = Session["Service"].ToString();
            var res = detailedreportformmanager.SaveDetailReport(detailedreportformmodel);
            var result = detailedreportformmanager.GetServicesAmount(Convert.ToInt64(Session["ReportID"]),Convert.ToInt32(Session["PanditID"]));
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


    }
}
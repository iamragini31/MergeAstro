using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;
using System.IO;
using System.Globalization;

namespace Pandit_Application.Controllers
{
    public class PaymentController : Controller
    {
        PaymentManger paymentmanger = new PaymentManger();
        PaymentModel paymentmodel = new PaymentModel();
        // GET: Payment
        public ActionResult Payment()
        {
            return View();
        } 
        public ActionResult AdminPayment()
        {
            return View();
        }

        public ActionResult GetAllPandits()
        {
            var list = paymentmanger.GetAllPandits();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FetchPaymentforservices(FormCollection form)
        {
            PaymentModel paymentmodel = new PaymentModel();

            paymentmodel.FromDate = form["FromDate"];
            paymentmodel.ToDate = form["ToDate"];
            paymentmodel.PanditId1 = form["PanditId"];


            var result = paymentmanger.FetchPaidPaymentforservices(paymentmodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FetchunpaidPaymentforservices(FormCollection form)
        {
            PaymentModel paymentmodel = new PaymentModel();

            paymentmodel.FromDate = form["FromDate"];
            paymentmodel.ToDate = form["ToDate"];
            paymentmodel.PanditId1 = form["PanditId"];


            var result = paymentmanger.FetchunPaidPaymentforservices(paymentmodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FetchunpaidPaymentforcallchat(FormCollection form)
        {
            PaymentModel paymentmodel = new PaymentModel();

            paymentmodel.FromDate = form["FromDate"];
            paymentmodel.ToDate = form["ToDate"];
            paymentmodel.PanditId1 = form["PanditId"];


            var result = paymentmanger.FetchunPaidPaymentforchatcall(paymentmodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FetchpaidPaymentforcallchat(FormCollection form)
        {
            PaymentModel paymentmodel = new PaymentModel();

            paymentmodel.FromDate = form["FromDate"];
            paymentmodel.ToDate = form["ToDate"];
            paymentmodel.PanditId1 = form["PanditId"];


            var result = paymentmanger.FetchPaidPaymentforchatcall(paymentmodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SavePayment(int ID)
        {
            var res = paymentmanger.SavePayment(ID);

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePayment(int ID)
        {
            var res = paymentmanger.updatePayment(ID);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
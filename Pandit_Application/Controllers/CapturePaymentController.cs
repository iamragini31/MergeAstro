using Pandit_ApplicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandit_Application.Controllers
{
    public class CapturePaymentController : Controller
    {
        // GET: CapturePayment
        public ActionResult CapturePayment()
        {
            RazorpayOrdermodel model = new RazorpayOrdermodel();
            model.id = Session["PaymentOrderid"].ToString();
            model.amount = Convert.ToInt64(Session["PaymentAmount"]);
            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;


namespace Pandit_Application.Controllers
{
    public class OrderAcceptedController : Controller
    {
        // GET: OrderAccepted

        OrderAcceptedManager orderaccepted = new OrderAcceptedManager();
        OrderAcceptedModel orderaccptedmodel = new OrderAcceptedModel();
        public ActionResult OrderAccepted()
        {
            return View();
        }


        public ActionResult BindServices()
        {

            var res = orderaccepted.BindService(Session["PanditID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Complete(string orderid)
        {

            var res = orderaccepted.updateservice(Session["PanditID"].ToString(), orderid);
            return Json(res, JsonRequestBehavior.AllowGet);


        }

    }
}
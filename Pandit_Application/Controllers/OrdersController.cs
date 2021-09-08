using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        OrdersManager ordermanager = new OrdersManager();
        OrdersModel ordermodel = new OrdersModel();

        public ActionResult Orders()
        {
            return View();
        }


        public ActionResult BindServices()
        {

            var res = ordermanager.BindService(Session["PanditID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Updateservice(string orderid)
        {

            var res = ordermanager.updateservice(Session["PanditID"].ToString(), orderid);
            return Json(res, JsonRequestBehavior.AllowGet);


        }

        public ActionResult RejectService(string orderid)
        {

            var res = ordermanager.updateservice(Session["PanditID"].ToString(), orderid);
            return Json(res, JsonRequestBehavior.AllowGet);


        }
    }
}
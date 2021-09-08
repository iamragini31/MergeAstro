using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;


namespace Pandit_Application.Controllers
{
    public class CompletedOrdersController : Controller
    {
        // GET: CompletedOrders

        CompletedOrdersManager manager = new CompletedOrdersManager();
        CompletedOrdersModel model = new CompletedOrdersModel();
        public ActionResult CompletedOrders()
        {
            return View();
        }



        public ActionResult BindServices()
        {

            var res = manager.BindService(Session["PanditID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);


        }
    }
}
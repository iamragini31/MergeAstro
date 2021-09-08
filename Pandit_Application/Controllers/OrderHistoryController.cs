using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class OrderHistoryController : Controller
    {
        OrderHistoryManager orderhistorymanager = new OrderHistoryManager();
        OrderHistoryModel orderhistorymodel = new OrderHistoryModel();
        // GET: OrderHistory
        public ActionResult OrderHistory()
        {
            return View();
        }

        public ActionResult BindServices()
        {
            var res = orderhistorymanager.BindService(Session["CustomerID"].ToString(),"Service");
            return Json(res, JsonRequestBehavior.AllowGet);          
        }

        public ActionResult Bindpuja()
        {
            var res = orderhistorymanager.BindPuja(Session["CustomerID"].ToString(), "Puja");
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BindCalldetails()
        {
            var res = orderhistorymanager.BindCallservice(Session["CustomerID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BindChatdetails()
        {
            var res = orderhistorymanager.BindChatservice(Session["CustomerID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BindReport()
        {
            var res = orderhistorymanager.BindReport(Session["CustomerID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
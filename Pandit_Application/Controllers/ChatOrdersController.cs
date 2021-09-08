using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class ChatOrdersController : Controller
    {
        // GET: ChatOrders
        ChatOrdersManager chatordersmanager = new ChatOrdersManager();
        ChatOrdersModel chatordersmodel = new ChatOrdersModel();


        public ActionResult ChatOrders()
        {
            ViewBag.UserName = Session["UserName"];
            ViewBag.UserId = Session["PanditID"];
            return View();
        }
        public ActionResult BindChat()
        {

            var res = chatordersmanager.BindChat(Session["PanditID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);


        }
    }
}
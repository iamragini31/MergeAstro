using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Pandit_ApplicationEntity;
using System.Data;
using System.Data.SqlClient;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class DefaultAdminPanditController : Controller
    {
        // GET: DefaultAdminPandit
        OrderHistoryManager manager = new OrderHistoryManager();
        OrderHistoryModel model = new OrderHistoryModel();
        public ActionResult DefaultAdminPandit()
        {
            var session = Session["PanditID"];
            var sessionUserId = Session["PanditID"];
            if (sessionUserId == null)
            {
               return RedirectToAction("Login", "Login");
            }
            else
            {

                model = manager.Bindtab(Convert.ToInt64(sessionUserId));
                return View(model);
            }
           
        }
    }
}
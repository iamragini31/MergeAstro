using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class DefaultAdminPortalController : Controller
    {
        // GET: DefaultAdminPortal
        DefaultAdminPortalManager manager = new DefaultAdminPortalManager();
        DefaultAdminPortalModel model = new DefaultAdminPortalModel();
        public ActionResult DefaultAdminPortal()
        {
            model = manager.Bindtab();

            return View(model);
        }
        public ActionResult Admin()
        {
            model = manager.Bindtab();

            return View(model);
        }
    }
}
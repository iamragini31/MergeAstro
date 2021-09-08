using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class TalktoSpecialistController : Controller
    {

        TalktoSpecialistManager talktospecialistManger = new TalktoSpecialistManager();
        // GET: TalktoSpecialist
        public ActionResult TalktoSpecialist()
        {
            var list = talktospecialistManger.GetSpecialistsImagesWithName();
            return View(list);
        }
    }
}
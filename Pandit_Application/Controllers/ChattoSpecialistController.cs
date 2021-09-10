using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;

using Pandit_ApplicationManager;


namespace Pandit_Application.Controllers
{
    public class ChattoSpecialistController : Controller
    {
        SpecialistChatManager chattospecialistmanager = new SpecialistChatManager();
        // GET: ChattoSpecialist
        public ActionResult ChattoSpecialist()
        {
           var list= chattospecialistmanager.GetSpecialistsImagesWithName();
            return View(list);
        }

     
    }
}
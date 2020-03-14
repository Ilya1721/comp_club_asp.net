using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    public class EventController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["events"] = DataContext.Events.Where(e => e.GameID != null).ToList();

            return View();
        }

        public ActionResult Show(int ID)
        {
            ViewData["events"] = DataContext.Events.Where(e => e.EventID == ID).ToList();

            return View();
        }

        public ActionResult Visits()
        {
            ViewData["visits"] = DataContext.UserEventPivots.
                Where(e => e.ApplicationUserEmail == User.Identity.Name)
                .Where(e => e.Event.GameID == null)
                .ToList();

            return View();
        }

        public ActionResult EventParticipations()
        {
            ViewData["participations"] = DataContext.UserEventPivots.
                Where(e => e.ApplicationUserEmail == User.Identity.Name)
                .Where(e => e.Event.GameID != null)
                .ToList();

            return View();
        }
    }
}
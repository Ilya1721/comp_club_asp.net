using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    public class EventParticipationController : ApplicationController
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewData["participations"] = DataContext.UserEventPivots.
                Where(e => e.ApplicationUserEmail == User.Identity.Name)
                .Where(e => e.Event.GameID != null)
                .ToList();

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var Context = DataContext;
            ViewData["events"] = Context.Events.
                Where(e => e.GameID != null).ToList();
            ViewData["eventRoles"] = Context.EventRoles.ToList();

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Store()
        {
            var Context = DataContext;
            Context.UserEventPivots.Add(new Models.UserEventPivot
            {
                ApplicationUserEmail = User.Identity.Name,
                EventID = int.Parse(Request.Params["EventID"]),
                EventRoleID = int.Parse(Request.Params["EventRoleID"]),
                Place = int.Parse(Request.Params["Place"]),
                StartDate = DateTime.Parse(Request.Params["StartDate"]),
                EndDate = DateTime.Parse(Request.Params["EndDate"]),
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "EventParticipation"));
        }
    }
}
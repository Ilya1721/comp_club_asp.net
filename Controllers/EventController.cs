using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var Context = DataContext;
            ViewData["eventTypes"] = Context.EventTypes.ToList();
            ViewData["halls"] = Context.Halls.ToList();
            ViewData["games"] = Context.Games.ToList();

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Store()
        {
            var Context = DataContext;
            Debug.WriteLine(Request.Params["EventTypeID"]);
            Context.Events.Add(new Models.Event
            {
                EventTypeID = int.Parse(Request.Params["EventTypeID"]),
                HallID = int.Parse(Request.Params["HallID"]),
                GameID = int.Parse(Request.Params["GameID"]),
                Description = Request.Params["Description"],
                Price = int.Parse(Request.Params["Price"]),
                StartDate = DateTime.Parse(Request.Params["StartDate"]),
                EndDate = DateTime.Parse(Request.Params["EndDate"]),
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Event"));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? EventID)
        {
            if (EventID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Context = DataContext;
            ViewData["eventTypes"] = Context.EventTypes.ToList();
            ViewData["halls"] = Context.Halls.ToList();
            ViewData["games"] = Context.Games.ToList();
            ViewData["event"] = Context.Events.Find(EventID);

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? EventRoleID)
        {
            var Context = DataContext;
            Context.EventRoles.Find(EventRoleID)
                .Name = Request.Params["Name"];
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "EventRole"));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public RedirectResult Delete(int? EventRoleID)
        {
            if (EventRoleID != null)
            {
                var Context = DataContext;
                Context.EventRoles.Remove(Context.EventRoles.Find(EventRoleID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "EventRole"));
        }
    }
}

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
        public RedirectResult Update(int? EventID)
        {
            var Context = DataContext;
            var theEvent = Context.Events.Find(EventID);
            theEvent.EventTypeID = int.Parse(Request.Params["EventTypeID"]);
            theEvent.HallID = int.Parse(Request.Params["HallID"]);
            theEvent.GameID = int.Parse(Request.Params["GameID"]);
            theEvent.Description = Request.Params["Description"];
            theEvent.Price = int.Parse(Request.Params["Price"]);
            theEvent.StartDate = DateTime.Parse(Request.Params["StartDate"]);
            theEvent.EndDate = DateTime.Parse(Request.Params["EndDate"]);
                
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Event"));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public RedirectResult Delete(int? EventID)
        {
            if (EventID != null)
            {
                var Context = DataContext;
                Context.Events.Remove(Context.Events.Find(EventID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Event"));
        }
    }
}

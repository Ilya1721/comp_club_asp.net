using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ComputerClub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventTypeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["eventTypes"] = DataContext.EventTypes.ToList();
            Debug.WriteLine(Roles.IsUserInRole("Admin"));

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Store()
        {
            var Context = DataContext;
            Context.EventTypes.Add(new Models.EventType
            {
                Name = Request.Params["Name"]
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "EventType"));
        }

        [HttpGet]
        public ActionResult Edit(int? EventTypeID)
        {
            if (EventTypeID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["eventType"] = DataContext.EventTypes.Find(EventTypeID);

            return View();
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? EventTypeID)
        {
            var Context = DataContext;
            Context.EventTypes.Find(EventTypeID)
                .Name = Request.Params["Name"];
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "EventType"));
        }

        [HttpPost]
        public RedirectResult Delete(int? EventTypeID)
        {
            if (EventTypeID != null)
            {
                var Context = DataContext;
                Context.EventTypes.Remove(Context.EventTypes.Find(EventTypeID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "EventType"));
        }
    }
}
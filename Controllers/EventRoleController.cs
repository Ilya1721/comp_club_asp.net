using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventRoleController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["eventRoles"] = DataContext.EventRoles.ToList();

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
            Context.EventRoles.Add(new Models.EventRole
            {
                Name = Request.Params["Name"]
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "EventRole"));
        }

        [HttpGet]
        public ActionResult Edit(int? EventRoleID)
        {
            if (EventRoleID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["eventRole"] = DataContext.EventRoles.Find(EventRoleID);

            return View();
        }

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
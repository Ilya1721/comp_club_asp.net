using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    public class VisitController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["visits"] = DataContext.UserEventPivots.
                Where(e => e.ApplicationUserEmail == User.Identity.Name)
                .Where(e => e.Event.GameID == null)
                .ToList();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var Context = DataContext;
            ViewData["halls"] = Context.Halls.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Store()
        {
            var Context = DataContext;
            Context.UserEventPivots.Add(new Models.UserEventPivot
            {
                ApplicationUserEmail = User.Identity.Name,
                EventID = Context.Events.ToList().
                          Find(e => e.EventType.Name == "Візит" &&
                                    e.HallID == int.Parse(Request.Params["HallID"])).EventID,
                EventRoleID = Context.EventRoles.ToList().Find(e => e.Name == "Гравець").EventRoleID,
                Place = int.Parse(Request.Params["Place"]),
                StartDate = DateTime.Parse(Request.Params["StartDate"]),
                EndDate = DateTime.Parse(Request.Params["EndDate"]),
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Visit"));
        }
    }
}
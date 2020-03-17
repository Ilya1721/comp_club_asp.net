using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    public class ScheduleController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? ClubID)
        {
            if (ClubID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["club"] = DataContext.Clubs.Find(ClubID);

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? ClubID)
        {
            var Context = DataContext;
            var club = Context.Clubs.Find(ClubID);
            club.Schedule = Request.Params["Schedule"];

            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Schedule"));
        }
    }
}
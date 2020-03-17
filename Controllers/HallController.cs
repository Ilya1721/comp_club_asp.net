using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HallController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["halls"] = DataContext.Halls.ToList();

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
            Context.Halls.Add(new Models.Hall
            {
                Name = Request.Params["Name"]
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Hall"));
        }

        [HttpGet]
        public ActionResult Edit(int? HallID)
        {
            if (HallID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["hall"] = DataContext.Halls.Find(HallID);

            return View();
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? HallID)
        {
            var Context = DataContext;
            Context.Halls.Find(HallID)
                .Name = Request.Params["Name"];
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Hall"));
        }

        [HttpPost]
        public RedirectResult Delete(int? HallID)
        {
            if (HallID != null)
            {
                var Context = DataContext;
                Context.Halls.Remove(Context.Halls.Find(HallID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Hall"));
        }
    }
}
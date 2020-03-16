using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenreController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["genres"] = DataContext.Genres.ToList();

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
            Context.Genres.Add(new Models.Genre
            {
                Name = Request.Params["Name"]
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Genre"));
        }

        [HttpGet]
        public ActionResult Edit(int? GenreID)
        {
            if (GenreID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["genre"] = DataContext.Genres.Find(GenreID);

            return View();
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? GenreID)
        { 
            var Context = DataContext;
            Context.Genres.Find(GenreID)
                .Name = Request.Params["Name"];
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Genre"));
        }

        [HttpPost]
        public RedirectResult Delete(int? GenreID)
        {
            if (GenreID != null)
            {
                var Context = DataContext;
                Context.Genres.Remove(Context.Genres.Find(GenreID));
                Context.SaveChanges();
            }
            
            return Redirect(Url.Action("Index", "Genre"));
        }
    }
}
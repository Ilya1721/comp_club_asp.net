using System;
using System.Collections.Generic;
using System.Linq;
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
        public RedirectResult Store()
        {
            return Redirect(Url.Action("Index", "Genre"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerClub.Models;
using ComputerClub.DB;

namespace ComputerClub.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["games"] = DataContext.Games.ToList();
            ViewData["platforms"] = DataContext.Platforms.ToList();
            ViewData["new_events"] = DataContext.Events.
                Where(g => g.GameID != null && g.EndDate > DateTime.Now).ToList();
            ViewData["old_events"] = DataContext.Events.
                Where(g => g.GameID != null && g.EndDate < DateTime.Now).ToList();

            return View("Index");
        }
    }
}
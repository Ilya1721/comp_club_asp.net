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

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerClub.Models;
using ComputerClub.DB;

namespace ComputerClub.Controllers
{
    public class HomeController : Controller
    {
        private ComputerClubContext db = new ComputerClubContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prices()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public ActionResult Games()
        {
            return View();
        }

        public ActionResult Platforms()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View(db.Tests.ToList());
        }
    }
}
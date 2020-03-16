using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
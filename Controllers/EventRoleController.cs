using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
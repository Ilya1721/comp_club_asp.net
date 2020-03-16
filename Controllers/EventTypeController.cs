using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ComputerClub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventTypeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["eventTypes"] = DataContext.EventTypes.ToList();
            Debug.WriteLine(Roles.IsUserInRole("Admin"));

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerClub.Models;
using ComputerClub.DB;
using System.Globalization;
using System.Threading;

namespace ComputerClub.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public ComputerClubContext DataContext
        {
            get { return new ComputerClubContext(); }
        }

        public ApplicationController()
        {
            ViewData["clubs"] = DataContext.Clubs.ToList();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
        }

    }
}
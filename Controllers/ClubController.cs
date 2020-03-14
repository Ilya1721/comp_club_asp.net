using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerClub.DB;
using ComputerClub.Models;
using System.Diagnostics;

namespace ComputerClub.Controllers
{
    public class ClubController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Price()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public FileContentResult GetPriceImage(int? itemId)
        {
            Club item = DataContext.Clubs.FirstOrDefault(p => p.ClubID == itemId);

            return item != null ? File(item.PriceImage, item.PriceImageMimeType) : null;
        }

        public FileContentResult GetLogoImage(int? itemId)
        {
            Club item = DataContext.Clubs.FirstOrDefault(p => p.ClubID == itemId);

            return item != null ? File(item.LogoImage, item.LogoImageMimeType) : null;
        }
    }
}
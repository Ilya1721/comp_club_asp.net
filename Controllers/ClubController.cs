using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerClub.DB;
using ComputerClub.Models;
using System.Diagnostics;
using System.Web.Security;
using System.Net;

namespace ComputerClub.Controllers
{
    public class ClubController : ApplicationController
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Price()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Logo()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? ClubID)
        {
            if (ClubID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["club"] = DataContext.Clubs.Find(ClubID);

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? ClubID)
        {
            var Context = DataContext;
            var club = Context.Clubs.Find(ClubID);
            club.Name = Request.Params["Name"];
            club.Street = Request.Params["Street"];
            club.House = Request.Params["House"];
            club.Flat = Request.Params["Flat"];
            club.Phone = Request.Params["Phone"];

            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Club"));
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
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
    public class PlatformController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["platforms"] = DataContext.Platforms.ToList();
            
            return View();
        }

        public FileContentResult GetImage(int? itemId)
        {
            Platform item = DataContext.Platforms.FirstOrDefault(p => p.PlatformID == itemId);

            return item != null ? File(item.Image, item.ImageMimeType) : null;
        }
    }
}
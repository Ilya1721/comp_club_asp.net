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
    public class GameController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["games"] = DataContext.Games.ToList();
            return View();
        }

        public FileContentResult GetImage(int? itemId)
        {
            Game item = DataContext.Games.FirstOrDefault(p => p.GameID == itemId);

            return item != null ? File(item.Image, item.ImageMimeType) : null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerClub.DB;
using ComputerClub.Models;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using ComputerClub.Infrastructure;
using System.Drawing;
using System.Net;

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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["platforms"] = DataContext.Platforms.ToList();
            ViewData["genres"] = DataContext.Genres.ToList();

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Store()
        {
            var Context = DataContext;
            var upload = HttpContext.Request.Files[0];
            if (upload.FileName != "")
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                var extension = Path.GetExtension(Server.MapPath("~/Content/img/" + fileName)).ToLower();
                ImageFormat imageFormat = ImageFormat.Jpeg;

                switch (extension)
                {
                    case ".jfif": imageFormat = ImageFormat.Jpeg; break;
                    case ".jpg": imageFormat = ImageFormat.Jpeg; break;
                    case ".png": imageFormat = ImageFormat.Png; break;
                    case ".gif": imageFormat = ImageFormat.Gif; break;
                    case ".icon": imageFormat = ImageFormat.Icon; break;
                }

                var GameImage = ImageLoader.
                    ImageToByteArray(Image.FromFile(Server.MapPath("~/Content/img/" + fileName)), imageFormat);
                var GameImageMimeType = imageFormat;

                Debug.WriteLine(int.Parse(Request.Params["PlatformID"]));

                Context.Games.Add(new Models.Game
                {
                    Name = Request.Params["Name"],
                    PlatformID = int.Parse(Request.Params["PlatformID"]),
                    GenreID = int.Parse(Request.Params["GenreID"]),
                    Image = GameImage,
                    ImageMimeType = "image/" + extension.Substring(1)
                });

                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Game"));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? GameID)
        {
            if (GameID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["platforms"] = DataContext.Platforms.ToList();
            ViewData["genres"] = DataContext.Genres.ToList();
            ViewData["game"] = DataContext.Games.Find(GameID);

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? GameID)
        {
            var Context = DataContext;
            var upload = HttpContext.Request.Files[0];
            if (upload.FileName != "")
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                var extension = Path.GetExtension(Server.MapPath("~/Content/img/" + fileName)).ToLower();
                ImageFormat imageFormat = ImageFormat.Jpeg;

                switch (extension)
                {
                    case ".jfif": imageFormat = ImageFormat.Jpeg; break;
                    case ".jpg": imageFormat = ImageFormat.Jpeg; break;
                    case ".png": imageFormat = ImageFormat.Png; break;
                    case ".gif": imageFormat = ImageFormat.Gif; break;
                    case ".icon": imageFormat = ImageFormat.Icon; break;
                }

                var GameImage = ImageLoader.
                    ImageToByteArray(Image.FromFile(Server.MapPath("~/Content/img/" + fileName)), imageFormat);
                var GameImageMimeType = imageFormat;

                var game = Context.Games.Find(GameID);

                game.Name = Request.Params["Name"];
                game.PlatformID = int.Parse(Request.Params["PlatformID"]);
                game.GenreID = int.Parse(Request.Params["GenreID"]);
                game.Image = GameImage;
                game.ImageMimeType = "image/" + extension.Substring(1);
            }
            else
            {
                var game = Context.Games.Find(GameID);
                game.Name = Request.Params["Name"];
                game.PlatformID = int.Parse(Request.Params["PlatformID"]);
                game.GenreID = int.Parse(Request.Params["GenreID"]);
            }

            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Game"));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public RedirectResult Delete(int? GameID)
        {
            if (GameID != null)
            {
                var Context = DataContext;
                Context.Games.Remove(Context.Games.Find(GameID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Game"));
        }
    }
}
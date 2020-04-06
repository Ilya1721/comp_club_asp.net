using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerClub.DB;
using ComputerClub.Models;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using ComputerClub.Infrastructure;
using System.Drawing;
using System.Net;

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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Store()
        {
            var Context = DataContext;
            var upload = HttpContext.Request.Files[0];
            if (upload != null)
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

                var PlatformImage = ImageLoader.
                    ImageToByteArray(Image.FromFile(Server.MapPath("~/Content/img/" + fileName)), imageFormat);
                var PlatformImageMimeType = imageFormat;

                Context.Platforms.Add(new Models.Platform
                {
                    Name = Request.Params["Name"],
                    Image = PlatformImage,
                    ImageMimeType = "image/" + extension.Substring(1)
            });

                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Platform"));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? PlatformID)
        {
            if (PlatformID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["platform"] = DataContext.Platforms.Find(PlatformID);

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? PlatformID)
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

                var PlatformImage = ImageLoader.
                    ImageToByteArray(Image.FromFile(Server.MapPath("~/Content/img/" + fileName)), imageFormat);
                var PlatformImageMimeType = imageFormat;

                var platform = Context.Platforms.Find(PlatformID);

                platform.Name = Request.Params["Name"];
                platform.Image = PlatformImage;
                platform.ImageMimeType = "image/" + extension.Substring(1);
            }
            else
            {
                var platform = Context.Platforms.Find(PlatformID);
                platform.Name = Request.Params["Name"];
            }

            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Platform"));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public RedirectResult Delete(int? PlatformID)
        {
            if (PlatformID != null)
            {
                var Context = DataContext;
                Context.Platforms.Remove(Context.Platforms.Find(PlatformID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Platform"));
        }
    }
}
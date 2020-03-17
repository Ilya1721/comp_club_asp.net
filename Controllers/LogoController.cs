using ComputerClub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    public class LogoController : ApplicationController
    {
        public ActionResult Index()
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

                var PriceImage = ImageLoader.
                    ImageToByteArray(Image.FromFile(Server.MapPath("~/Content/img/" + fileName)), imageFormat);
                var PriceImageMimeType = imageFormat;

                club.LogoImage = PriceImage;
                club.LogoImageMimeType = "image/" + extension.Substring(1);

                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Price"));
        }
    }
}
using ComputerClub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComputerClub.Controllers
{
    public class PriceController : ApplicationController
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
        public RedirectResult Update(int? GenreID)
        {
            Debug.WriteLine("Hello");
            var Context = DataContext;
            //var club = Context.Clubs.Find(ClubID);
            //var upload = Request.Params["upload"];
            var upload = HttpContext.Request.Files[0];
            Debug.WriteLine(upload);
            //if (upload != null)
            //{
            //    Debug.WriteLine("Upload is not null");
            //    string fileName = System.IO.Path.GetFileName(upload.FileName);
            //    upload.SaveAs(Server.MapPath("~/Content/img/" + fileName));
            //    Debug.WriteLine(Server.MapPath("~/Content/img/" + fileName));
            //    var extension = Path.GetExtension(Server.MapPath("~/Content/img/" + fileName)).ToLower();
            //    ImageFormat imageFormat = ImageFormat.Jpeg;
            //    switch (extension)
            //    {
            //        case ".jfif": imageFormat = ImageFormat.Jpeg; break;
            //        case ".jpg": imageFormat = ImageFormat.Jpeg; break;
            //        case ".png": imageFormat = ImageFormat.Png; break;
            //        case ".gif": imageFormat = ImageFormat.Gif; break;
            //        case ".icon": imageFormat = ImageFormat.Icon; break;
            //    }
            //    var PriceImage = ImageLoader.
            //        ImageToByteArray(Image.FromFile(Server.MapPath("~/Content/img/" + fileName)), imageFormat);
            //}

            return Redirect(Url.Action("Index", "Price"));
        }
    }
}
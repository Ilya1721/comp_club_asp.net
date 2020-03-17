using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace ComputerClub.Infrastructure
{
    public class ImageLoader
    {
        public static byte[] ImageToByteArray(Image theImage, ImageFormat imageFormat)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, imageFormat);
                return memoryStream.ToArray();
            }
        }
    }
}
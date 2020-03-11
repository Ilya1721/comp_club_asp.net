using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerClub.Models
{
    public class Platform
    {
        public int PlatformID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }
    }
}
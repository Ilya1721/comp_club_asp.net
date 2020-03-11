using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerClub.Models
{
    public class Club
    {
        public int ClubID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string Phone { get; set; }
        public string Schedule { get; set; }
        public byte[] PriceImage { get; set; }
        public string PriceImageMimeType { get; set; }
        public byte[] LogoImage { get; set; }
        public string LogoImageMimeType { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerClub.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public int GenreID { get; set; }
        public int PlatformID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
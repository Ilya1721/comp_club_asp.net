using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerClub.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
    }
}
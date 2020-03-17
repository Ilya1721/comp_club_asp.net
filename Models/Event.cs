using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerClub.Models;

namespace ComputerClub.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public int EventTypeID { get; set; }
        public int HallID { get; set; }
        public int? GameID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual Game Game { get; set; }
    }
}
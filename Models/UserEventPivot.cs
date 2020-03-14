using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerClub.Models
{
    public class UserEventPivot
    {
        public int UserEventPivotID { get; set; } 
        public string ApplicationUserEmail { get; set; }
        public int EventID { get; set; }
        public int EventRoleID { get; set; }
        public int? Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventRole EventRole { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerClub.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ComputerClub.DB
{
    public class ComputerClubContext : DbContext
    {
        public ComputerClubContext() : base("ComputerClubDb") { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
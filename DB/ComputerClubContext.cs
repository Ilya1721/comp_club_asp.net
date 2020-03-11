using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerClub.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ComputerClub.DB
{
    public class ComputerClubContext : DbContext
    {
        public ComputerClubContext() : base("ComputerClubContext") { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
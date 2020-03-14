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
    public class ComputerClubContext : IdentityDbContext<ApplicationUser>
    {
        public ComputerClubContext() : base("ComputerClubContext") { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventRole> EventRoles { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEventPivot> UserEventPivots { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }

        public static ComputerClubContext Create()
        {
            return new ComputerClubContext();
        }
    }
}
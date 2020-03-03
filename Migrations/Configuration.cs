namespace ComputerClub.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using ComputerClub.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerClub.DB.ComputerClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ComputerClub.DB.ComputerClubContext";
        }

        protected override void Seed(ComputerClub.DB.ComputerClubContext context)
        {
            List<Genre> Genres = new List<Genre>
            {
                new Genre { Name = "Shooter"},
                new Genre { Name= "Survival" },
                new Genre { Name="MMORPG" },
                new Genre { Name="Sports Games" },
                new Genre { Name="Strategy" }
            };

            Genres.ForEach(g => context.Genres.Add(g));
            context.SaveChanges();
        }
    }
}

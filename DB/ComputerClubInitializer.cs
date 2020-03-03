using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ComputerClub.Models;

namespace ComputerClub.DB
{
    public class ComputerClubInitializer : System.Data.Entity . DropCreateDatabaseIfModelChanges<ComputerClubContext>
    {

        protected override void Seed(ComputerClubContext context)
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
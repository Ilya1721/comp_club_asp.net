using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ComputerClub.Models;
using System.Drawing;
using ComputerClub.Infrastructure;
using System.Diagnostics;

namespace ComputerClub.DB
{
    public class ComputerClubInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ComputerClubContext>
    {
        protected override void Seed(ComputerClubContext context)
        {
            Debug.WriteLine("seeding");

            List<Genre> Genres = new List<Genre>
            {
                new Genre { Name = "Shooter" },
                new Genre { Name = "Survival" },
                new Genre { Name = "MMORPG" },
                new Genre { Name = "Sports Games" },
                new Genre { Name = "Strategy" },
            };

            Genres.ForEach(g => context.Genres.Add(g));

            List<Platform> Platforms = new List<Platform>
            {
                new Platform
                {
                    Name = "Windows",
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\windows.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                }
            };

            Platforms.ForEach(g => context.Platforms.Add(g));
            context.SaveChanges();

            List<Game> Games = new List<Game>
            {
                new Game
                {
                    Name = "CS GO",
                    GenreID = 1,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\csgo.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "Dota 2",
                    GenreID = 3,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\dota2.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "League of Legends",
                    GenreID = 3,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\lol.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "GTA V",
                    GenreID = 1,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\gta5.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "Red Alert 3",
                    GenreID = 5,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\red-alert3.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "Red Dead Redemption 2",
                    GenreID = 1,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\red-dead-redemption2.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "Serious Sam 2",
                    GenreID = 1,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\serious-sam2.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "FIFA 2018",
                    GenreID = 4,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\fifa18.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
                new Game
                {
                    Name = "PES 2018",
                    GenreID = 4,
                    PlatformID = 1,
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\pes18.jfif")
                    ),
                    ImageMimeType = "image/jpeg",
                },
            };

            Games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

            List<Club> Clubs = new List<Club>
            {
                new Club
                {
                    Name = "CyberZone",
                    Street = "Разіна",
                    House = "17",
                    Flat = "ТЦ Метроград, 2-й поверх",
                    Phone = "+380(93)247-56-47",
                    Schedule = "Кожний день. 9.00-07.00",
                    PriceImage = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\price.gif")
                    ),
                    PriceImageMimeType = "image/gif",
                    LogoImage = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\ComputerClub\ComputerClub\Content\img\logo.png")
                    ),
                    LogoImageMimeType = "image/png",
                }
            };

            Clubs.ForEach(g => context.Clubs.Add(g));
            context.SaveChanges();
        }
            
    }
}
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

            List<Hall> Halls = new List<Hall>
            {
                new Hall
                {
                    Name = "Standard"
                },
                new Hall
                {
                    Name = "Pro"
                },
                new Hall
                {
                    Name = "VIP"
                }
            };

            Halls.ForEach(g => context.Halls.Add(g));
            context.SaveChanges();

            List<EventType> EventTypes = new List<EventType>
            {
                new EventType
                {
                    Name = "Турнір"
                },
                new EventType
                {
                    Name = "Виставка"
                },
                new EventType
                {
                    Name = "Візит"
                }
            };

            EventTypes.ForEach(g => context.EventTypes.Add(g));
            context.SaveChanges();

            List<EventRole> EventRoles = new List<EventRole>
            {
                new EventRole
                {
                    Name = "Гравець"
                },
                new EventRole
                {
                    Name = "Глядач"
                },
                new EventRole
                {
                    Name = "Організатор"
                }
            };

            EventRoles.ForEach(g => context.EventRoles.Add(g));
            context.SaveChanges();

            List<Event> Events = new List<Event>
            {
                new Event
                {
                    EventTypeID = 1,
                    HallID = 1,
                    GameID = 1,
                    Description = "Як і завжди наш клуб продовжує підтримувати" +
                    " кіберспорт і організовувати турніри найвищого рівня.Не пропустіть" +
                    " найближчий турнір - відбіркові на справжню кіберолімпіаду WCG 2019." +
                    " Відбіркові ігри на лані пройдуть в нашому клубі 27-28 грудня.",
                    Price = 0.00,
                    StartDate = new DateTime(2020, 3, 11, 3, 15, 0),
                    EndDate = new DateTime(2020, 4, 11, 3, 15, 0),
                },
                new Event
                {
                    EventTypeID = 1,
                    HallID = 1,
                    GameID = 2,
                    Description = "Як і завжди наш клуб продовжує підтримувати" +
                    " кіберспорт і організовувати турніри найвищого рівня.Не пропустіть" +
                    " найближчий турнір - відбіркові на справжню кіберолімпіаду WCG 2019." +
                    " Відбіркові ігри на лані пройдуть в нашому клубі 27-28 грудня.",
                    Price = 0.00,
                    StartDate = new DateTime(2020, 12, 21, 2, 0, 0),
                    EndDate = new DateTime(2020, 4, 11, 3, 15, 0),
                },
                new Event
                {
                    EventTypeID = 1,
                    HallID = 1,
                    GameID = 2,
                    Description = "Як і завжди наш клуб продовжує підтримувати" +
                    " кіберспорт і організовувати турніри найвищого рівня.Не пропустіть" +
                    " найближчий турнір - відбіркові на справжню кіберолімпіаду WCG 2019." +
                    " Відбіркові ігри на лані пройдуть в нашому клубі 27-28 грудня.",
                    Price = 0.00,
                    StartDate = new DateTime(2020, 01, 08, 3, 15, 0),
                    EndDate = new DateTime(2020, 01, 10, 3, 15, 1),
                },
                new Event
                {
                    EventTypeID = 3,
                    HallID = 1,
                    GameID = null,
                    Description = "Ви завжди можете прийти та пограти в нашому клубі",
                    Price = 10.00,
                    StartDate = new DateTime(2020, 12, 21, 15, 0, 0),
                    EndDate = new DateTime(2020, 12, 21, 19, 0, 0),
                },
                new Event
                {
                    EventTypeID = 1,
                    HallID = 1,
                    GameID = 9,
                    Description = "Як і завжди наш клуб продовжує підтримувати" +
                    " кіберспорт і організовувати турніри найвищого рівня.Не пропустіть" +
                    " найближчий турнір - відбіркові на справжню кіберолімпіаду WCG 2019." +
                    " Відбіркові ігри на лані пройдуть в нашому клубі 27-28 грудня.",
                    Price = 0.00,
                    StartDate = new DateTime(2020, 12, 23, 3, 15, 0),
                    EndDate = new DateTime(2020, 12, 27, 3, 15, 0),
                },
                new Event
                {
                    EventTypeID = 3,
                    HallID = 2,
                    GameID = null,
                    Description = "Ви завжди можете прийти та пограти в нашому клубі",
                    Price = 20.00,
                    StartDate = new DateTime(2020, 11, 21, 9, 0, 0),
                    EndDate = new DateTime(2020, 11, 21, 15, 0, 0),
                },
                new Event
                {
                    EventTypeID = 3,
                    HallID = 3,
                    GameID = null,
                    Description = "Ви завжди можете прийти та пограти в нашому клубі",
                    Price = 30.00,
                    StartDate = new DateTime(2020, 12, 23, 14, 0, 0),
                    EndDate = new DateTime(2020, 12, 23, 18, 0, 0),
                }
            };

            Events.ForEach(g => context.Events.Add(g));
            context.SaveChanges();

            List<UserEventPivot> UserEventPivots = new List<UserEventPivot>
            {
                new UserEventPivot
                {
                    ApplicationUserEmail = "test@test.com",
                    EventID = 4,
                    EventRoleID = 2,
                    Place = 17,
                    StartDate = new DateTime(2020, 12, 23, 14, 0, 0),
                    EndDate = new DateTime(2020, 12, 23, 18, 0, 0),
                },
                new UserEventPivot
                {
                    ApplicationUserEmail = "test@test.com",
                    EventID = 6,
                    EventRoleID = 2,
                    Place = 18,
                    StartDate = new DateTime(2020, 12, 24, 14, 0, 0),
                    EndDate = new DateTime(2020, 12, 24, 18, 0, 0),
                },
                new UserEventPivot
                {
                    ApplicationUserEmail = "test@test.com",
                    EventID = 7,
                    EventRoleID = 2,
                    Place = 19,
                    StartDate = new DateTime(2020, 12, 25, 15, 0, 0),
                    EndDate = new DateTime(2020, 12, 25, 19, 0, 0),
                },
                new UserEventPivot
                {
                    ApplicationUserEmail = "test@test.com",
                    EventID = 1,
                    EventRoleID = 1,
                    Place = 17,
                    StartDate = new DateTime(2020, 12, 26, 14, 0, 0),
                    EndDate = new DateTime(2020, 12, 28, 18, 0, 0),
                },
            };

            UserEventPivots.ForEach(g => context.UserEventPivots.Add(g));
            context.SaveChanges();
        }      
    }
}
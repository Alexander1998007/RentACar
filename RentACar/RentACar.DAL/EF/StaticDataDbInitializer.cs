using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.DAL.EF
{
    public class StaticDataDbInitializer
    {
        //public static Rental[] InitializeRentals()
        //{
        //    var rentals = new Rental[]
        //    {
        //        new Rental
        //        {
        //            CarId=1,
        //            ApplicationUserId=1,
        //            StartCarRental=DateTime.UtcNow,
        //            EndCarRental=DateTime.UtcNow.AddDays(2),
        //            Price=200,
        //            CreatedAt=DateTime.UtcNow,
        //            UpdatedAt=DateTime.UtcNow,
        //        },
        //        new Rental
        //        {
        //            CarId=2,
        //            ApplicationUserId=2,
        //            StartCarRental=DateTime.UtcNow,
        //            EndCarRental=DateTime.UtcNow.AddDays(3),
        //            Price=300,
        //            CreatedAt=DateTime.UtcNow,
        //            UpdatedAt=DateTime.UtcNow,
        //        },
        //        new Rental
        //        {
        //            CarId=3,
        //            ApplicationUserId=3,
        //            StartCarRental=DateTime.UtcNow,
        //            EndCarRental=DateTime.UtcNow.AddDays(2),
        //            Price=200,
        //            CreatedAt=DateTime.UtcNow,
        //            UpdatedAt=DateTime.UtcNow,
        //        }
        //    };

        //    return rentals;
        //}

        //public static IEnumerable<ApplicationUser> InitializeUsers()
        //{
        //    // TODO:

        //    throw new NotImplementedException();
        //}

        //public static ApplicationUser[] InitializeApplicationUsers()
        //{
        //    var ApplicationUsers = new ApplicationUser[]
        //    {
        //        ApplicationUser.Create("user1@email.com", "user1@email.com", "Peter", "Quill"),
        //        ApplicationUser.Create("user2@email.com", "user2@email.com", "Peter", "Parker"),
        //        ApplicationUser.Create("user3@email.com", "user3@email.com", "Tony", "Stark"),
        //        ApplicationUser.Create("user4@email.com", "user4@email.com", "Steven", "Rogers"),
        //        ApplicationUser.Create("user5@email.com", "user5@email.com", "Bruce", "Banner")
        //    };

        //    return ApplicationUsers;
        //}

        //public static Car[] InitializeCars()
        //{
        //    var cars = new Car[]
        //    {
        //        Car.Create("1GKFK16308J223015", "TEST01", "Audi", "A4", 240),
        //        Car.Create("1FDXX46F02EC15683", "TEST02", "Audi", "A3", 133),
        //        Car.Create("1G1YY2182K5182195", "TEST03", "Volkswagen", "Golf", 200),
        //        Car.Create("1GCDT19W828263783", "TEST04", "Volkswagen", "Passat", 140),
        //        Car.Create("1GBE6H1P1RJ132646", "TEST05", "BMW", "M3", 321),
        //        Car.Create("1G1JE6SG2D4298321", "TEST06", "Ford", "Focus", 64),
        //        Car.Create("3B4GM07Y9KM982834", "TEST07", "Fiat", "500", 82)
        //    };

        //    return cars;
        //}
    }
}

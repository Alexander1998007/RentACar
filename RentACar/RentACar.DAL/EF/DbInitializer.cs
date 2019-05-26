using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using RentACar.DAL.Entities;

namespace RentACar.DAL.EF
{
    public static class DbInitializer
    {
        public static void Initialize(RentACarContext context)
        {
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                    new Car
                    {
                        VIN = "5GN876GN09FG57HVN",
                        RegistrationNumber = "АП4556ИЕ",
                        Brand = "Audi",
                        Model = "TT",
                        Price = 50,
                        CreatedAt = new System.DateTime(2015, 7, 20, 18, 30, 25),
                        UpdatedAt = new System.DateTime(2013, 7, 20, 18, 30, 25)
                    },
                    new Car
                    {
                         VIN = "4CV76MJ89D54NB768",
                         RegistrationNumber = "КЕ5674ПИ",
                         Brand = "Ford",
                         Model = "Fiesta",
                         Price = 20,
                         CreatedAt = new System.DateTime(2014, 7, 20, 18, 30, 25),
                         UpdatedAt = new System.DateTime(2018, 7, 20, 18, 30, 25)
                    },
                    new Car
                    {
                        VIN = "S567B87IO4XVTY689",
                        RegistrationNumber = "ФІ4563СМ",
                        Brand = "Volvo",
                        Model = "X40",
                        Price = 30,
                        CreatedAt = new System.DateTime(2013, 7, 20, 18, 30, 25),
                        UpdatedAt = new System.DateTime(2018, 7, 20, 18, 30, 25)
                    },
                    new Car
                    {
                        VIN = "XCV45643BNU69G57",
                        RegistrationNumber = "МИ7650МП",
                        Brand = "Volvo",
                        Model = "X75",
                        Price = 35,
                        CreatedAt = new System.DateTime(2013, 7, 20, 18, 30, 25),
                        UpdatedAt = new System.DateTime(2014, 7, 20, 18, 30, 25)
                    },
                    new Car
                    {
                        VIN = "678341WEVCZRTECNM",
                        RegistrationNumber = "ЯЧ3451ЙК",
                        Brand = "Ford",
                        Model = "Kuga",
                        Price = 30,
                        CreatedAt = new System.DateTime(2011, 7, 20, 18, 30, 25),
                        UpdatedAt = new System.DateTime(2013, 7, 20, 18, 30, 25)
                    }
                );
                context.SaveChanges();
            }

            /*foreach (ApplicationUser ApplicationUser in StaticDataDbInitializer.InitializeApplicationUsers())
            {
                context.ApplicationUsers.Add(ApplicationUser);
            }
            context.SaveChanges();
            */

            //foreach (Rental rental in StaticDataDbInitializer.InitializeRentals())
            //{
            //    context.Rentals.Add(rental);
            //}
            //context.SaveChanges();

            // TODO: initialize users
        }
    }
}

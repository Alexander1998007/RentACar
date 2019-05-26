using AutoMapper;
using RentACar.BLL.DTO;
using RentACar.DAL.Entities;

namespace RentACar.BLL.Mappers
{
    public class Mapper
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Car, CarDTO>();
               cfg.CreateMap<ApplicationUser, ApplicationUserDTO>();
               cfg.CreateMap<Rental, RentalDTO>();
           })
           .CreateMapper();
    }
}

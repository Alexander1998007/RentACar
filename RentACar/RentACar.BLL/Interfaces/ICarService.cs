using RentACar.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.BLL.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> BrowseAsync();
        Task<CarDTO> CreateAsync(CarDTO car);
        Task<CarDTO> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(CarDTO car);
        Task<IEnumerable<CarDTO>> GetAllFromRentals(IEnumerable<RentalDTO> rentals);
        Task<IEnumerable<CarDTO>> FilterByCarSet(IEnumerable<CarDTO> cars);
        Task<IEnumerable<CarDTO>> FilterByRentals(IEnumerable<RentalDTO> rentalsDTO);
    }
}

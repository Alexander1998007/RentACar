using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.DAL.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetAsync(int id);
        Task<Car> GetByVinAsync(string vin);
        Task<IEnumerable<Car>> BrowseAsync();
        Task<Car> AddAsync(Car car);
        Task RemoveAsync(int id);
        Task UpdateAsync(Car car);
        Task SaveAsync();
        Task<IEnumerable<Car>> GetAllFromRentals(IEnumerable<Rental> rentals);
        Task<IEnumerable<Car>> FilterByCarSet(IEnumerable<Car> carsDomain);
    }
}

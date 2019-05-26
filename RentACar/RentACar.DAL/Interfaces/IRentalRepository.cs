using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.DAL.Interfaces
{
    public interface IRentalRepository
    {
        Task<Rental> GetAsync(int id);
        Task<IEnumerable<Rental>> BrowseAsync();
        Task AddAsync(Rental rental);
        Task RemoveAsync(int id);
        Task UpdateAsync(Rental rental);
        Task SaveAsync();
        Task<IEnumerable<Rental>> GetRentalsBetweenDates(DateTime startRentalDate, DateTime endRentalDate);
        Task<IEnumerable<Rental>> GetRentalsByAppUserId(string appUserId);
    }
}

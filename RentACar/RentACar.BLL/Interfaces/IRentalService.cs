using RentACar.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.BLL.Interfaces
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTO>> BrowseAsync();
        Task CreateAsync(RentalDTO car);
        Task<RentalDTO> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(RentalDTO rental);
        Task<IEnumerable<RentalDTO>> GetRentalsBetweenDates(DateTime start, DateTime end);
        Task<IEnumerable<RentalDTO>> GetUserRentals(string appUserId);
    }
}

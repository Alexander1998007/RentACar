using Microsoft.EntityFrameworkCore;
using RentACar.DAL.EF;
using RentACar.DAL.Entities;
using RentACar.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.DAL.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentACarContext _context;
        private bool _disposed;

        public RentalRepository(RentACarContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Rental>> BrowseAsync()
            => await Task.FromResult(_context.Rentals);

        public async Task<Rental> GetAsync(int id)
            => await Task.FromResult(await _context.Rentals.SingleOrDefaultAsync(x => x.Id == id));

        public async Task RemoveAsync(int id)
        {
            var rental = await GetAsync(id);
            _context.Rentals.Remove(rental);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task SaveAsync()
            => await Task.FromResult(_context.SaveChanges());

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Rental>> GetRentalsBetweenDates(DateTime startRentalDate, DateTime endRentalDate)
            => await Task.FromResult(_context.Rentals.Where
                (x => x.StartCarRentalDate < endRentalDate && x.EndCarRentalDate > startRentalDate));

        public async Task<IEnumerable<Rental>> GetRentalsByAppUserId(string appUserId)
            => await Task.FromResult(_context.Rentals.Where(
                x => x.AppUserId == appUserId));
    }
}

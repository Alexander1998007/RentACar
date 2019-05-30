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
    public class CarRepository : ICarRepository
    {
        private readonly RentACarContext _context;
        private bool _disposed;

        public CarRepository(RentACarContext context)
        {
            _context = context;
        }

        public async Task<Car> AddAsync(Car car)
        {
            _context.Cars.Add(car);
            await Task.CompletedTask;
            return car;
        }

        public async Task<IEnumerable<Car>> BrowseAsync()
            => await Task.FromResult(_context.Cars);

        public async Task<Car> GetAsync(int id)
        {
            return await Task.FromResult(await _context.Cars.SingleOrDefaultAsync(x => x.Id == id));
        }

        public async Task RemoveAsync(int id)
        {
            var car = await GetAsync(id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task SaveAsync()
            => await Task.FromResult(_context.SaveChanges());

        public async Task UpdateAsync(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

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

        public async Task<Car> GetByVinAsync(string vin)
            => await Task.FromResult(await _context.Cars.SingleOrDefaultAsync(x => x.VIN == vin));

        public async Task<IEnumerable<Car>> GetAllFromRentals(IEnumerable<Rental> rentals)
        {
            var cars = from c in _context.Cars
                       where
                       (from r in rentals
                        select r.CarId).Contains(c.Id)
                       select c;

            return await Task.FromResult(cars);
        }

        public async Task<IEnumerable<Car>> FilterByCarSet(IEnumerable<Car> carsDomain)
        {
            var cars = _context.Cars;
            var filteredCars = cars.Except(carsDomain);

            return await Task.FromResult(cars);
        }
    }
}

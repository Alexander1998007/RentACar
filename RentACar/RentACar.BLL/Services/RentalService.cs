using AutoMapper;
using RentACar.BLL.DTO;
using RentACar.BLL.Interfaces;
using RentACar.DAL.Entities;
using RentACar.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.BLL.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RentalDTO>> BrowseAsync()
        {
            var rentals = await _rentalRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<RentalDTO>>(rentals);
        }

        public async Task CreateAsync(RentalDTO rental)
        {
            var rentalToCheck = await _rentalRepository.GetAsync(rental.Id);
            if (rentalToCheck != null)
            {
                throw new Exception($"Rental with id: {rental.Id} already exists.");
            }

            var rentalToAdd = CreateRentalFromDTO(rental);

            await _rentalRepository.AddAsync(rentalToAdd);
            await _rentalRepository.SaveAsync();
        }

        private static Rental CreateRentalFromDTO(RentalDTO rental)
        {
            return Rental.Create(
                rental.CarId,
                rental.AppUserId,
                rental.StartCarRentalDate,
                rental.EndCarRentalDate,
                rental.PricePerDay);
        }

        public async Task<IEnumerable<RentalDTO>> GetRentalsBetweenDates(DateTime start, DateTime end)
        {
            var rentals = await _rentalRepository.GetRentalsBetweenDates(start, end);
            return _mapper.Map<IEnumerable<RentalDTO>>(rentals);
        }

        public async Task<RentalDTO> GetAsync(int id)
        {
            var rental = await _rentalRepository.GetAsync(id);
            return _mapper.Map<RentalDTO>(rental);
        }

        public async Task RemoveAsync(int id)
        {
            var rental = await _rentalRepository.GetAsync(id);
            if (rental == null)
            {
                throw new Exception($"Rental with ID: {id} does not exist.");
            }
            await _rentalRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(RentalDTO rental)
        {
            var rentalToUpdate = _mapper.Map<Rental>(rental);
            await _rentalRepository.UpdateAsync(rentalToUpdate);
        }

        public async Task<IEnumerable<RentalDTO>> GetUserRentals(string appUserId)
        {
            var rentals = await _rentalRepository.GetRentalsByAppUserId(appUserId);
            return _mapper.Map<IEnumerable<RentalDTO>>(rentals);
        }
    }
}

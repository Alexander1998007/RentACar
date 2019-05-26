using AutoMapper;
using RentACar.BLL.DTO;
using RentACar.BLL.Interfaces;
using RentACar.DAL.Entities;
using RentACar.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDTO>> BrowseAsync()
        {
            var cars = await _carRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }

        public async Task<CarDTO> CreateAsync(CarDTO car)
        {
            var carToCheck = await _carRepository.GetByVinAsync(car.VIN.ToUpperInvariant());
            if (carToCheck != null)
            {
                throw new Exception($"Car with VIN: {car.VIN} already exists.");
            }
            var carToAdd = Car.Create(car.VIN.ToUpperInvariant(), car.RegistrationNumber, car.Brand, car.Model, car.Price);
            await _carRepository.AddAsync(carToAdd);
            await _carRepository.SaveAsync();
            return car;
        }

        public async Task RemoveAsync(int id)
        {
            var car = await _carRepository.GetAsync(id);
            if (car == null)
            {
                throw new Exception($"Car with ID: {id} does not exist.");
            }
            await _carRepository.RemoveAsync(id);
        }

        public async Task<CarDTO> GetAsync(int id)
        {
            var car = await _carRepository.GetAsync(id);
            return _mapper.Map<CarDTO>(car);
        }

        public async Task UpdateAsync(CarDTO car)
        {
            var carToUpdate = _mapper.Map<Car>(car);
            await _carRepository.UpdateAsync(carToUpdate);
        }

        public async Task<IEnumerable<CarDTO>> GetAllFromRentals(IEnumerable<RentalDTO> rentals)
        {
            var rentalsDomain = _mapper.Map<IEnumerable<Rental>>(rentals);
            var cars = await _carRepository.GetAllFromRentals(rentalsDomain);

            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }

        public async Task<IEnumerable<CarDTO>> FilterByCarSet(IEnumerable<CarDTO> cars)
        {
            var carsDomain = _mapper.Map<IEnumerable<Car>>(cars);
            var filteredCars = await _carRepository.FilterByCarSet(carsDomain);

            return _mapper.Map<IEnumerable<CarDTO>>(filteredCars);
        }

        public async Task<IEnumerable<CarDTO>> FilterByRentals(IEnumerable<RentalDTO> rentalsDTO)
        {
            var rentals = _mapper.Map<IEnumerable<Rental>>(rentalsDTO);
            var carsToBeFiltered = await _carRepository.GetAllFromRentals(rentals);
            var cars = await _carRepository.FilterByCarSet(carsToBeFiltered);

            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.BLL.BusinessModels;
using RentACar.BLL.DTO;
using RentACar.BLL.Interfaces;
using RentACar.Models.CarViewModels;

namespace RentACar.Controllers
{
    
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IRentalService _rentalService;
        private FilterByDate _filterByDate = FilterByDate.Instance;

        public CarsController(ICarService carService,
            IRentalService rentalService)
        {
            _carService = carService;
            _rentalService = rentalService;
        }

        // GET: Cars
        public async Task<IActionResult> Index(DateTime startDate, DateTime endDate)
        {
            if (startDate >= DateTime.Today)
            {
                _filterByDate.SetDateFrom(startDate);
            }

            if (endDate >= DateTime.Today)
            {
                _filterByDate.SetDateTo(endDate);
            }

            ViewData["StartDate"] = _filterByDate.DateFrom;
            ViewData["EndDate"] = _filterByDate.DateTo;

            var rentals = await _rentalService.GetRentalsBetweenDates(startDate, endDate);
            var cars = await _carService.FilterByRentals(rentals);

            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int id)
            => View(await _carService.GetAsync(id));

        [Authorize]
        public IActionResult Rent(int id)
        {
            return RedirectToAction("Rent", "Rentals",
                new
                {
                    CarId = id,
                    StartDate = _filterByDate.DateFrom,
                    EndDate = _filterByDate.DateTo
                });
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateCarViewModel createCarViewModel)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CreateCarViewModel>()).CreateMapper();
                var carDto = mapper.Map<CreateCarViewModel, CarDTO>(createCarViewModel);
                await _carService.CreateAsync(carDto);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cars/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.BLL.DTO;
using RentACar.BLL.Interfaces;

namespace CarRentalApp.Website.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly ICarService _carService;
        private readonly IApplicationUserService _applicationUserService;

        public RentalsController(IRentalService rentalService,
            ICarService carService,
            IApplicationUserService applicationUserService)
        {
            _rentalService = rentalService;
            _carService = carService;
            _applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appUser = await _applicationUserService.GetCurrentUserAsync(HttpContext);
            var rentals = await _rentalService.GetUserRentals(appUser.Id);

            return View(rentals);
        }

        public IActionResult Search()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(RentalDTO rental)
        {
            var startDate = rental.StartCarRentalDate;
            var endDate = rental.EndCarRentalDate;

            return RedirectToAction("Index", "Cars",
                new
                {
                    StartDate = startDate,
                    EndDate = endDate
                });
        }

        //GET: Rentals/Rent
        [HttpGet]
        public async Task<IActionResult> Rent(int carId, DateTime startDate, DateTime endDate)
        {
            int daysBetween = CountDaysBetween(startDate, endDate);

            var car = await _carService.GetAsync(carId);
            var price = daysBetween * car.Price;
            var appUserId = await _applicationUserService.GetCurrentUserIdAsync(HttpContext);

            var rentalDTO = new RentalDTO
            {
                CarId = carId,
                Car = car,
                AppUserId = appUserId,
                StartCarRentalDate = startDate,
                EndCarRentalDate = endDate,
                PricePerDay = car.Price,
                FullPrice = price,
                RentalInDays = daysBetween,
            };

            return View(rentalDTO);
        }

        private static int CountDaysBetween(DateTime startDate, DateTime endDate)
        {
            return Convert.ToInt32((endDate - startDate).TotalDays) + 1;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalDTO rentalDTO)
        {
            try
            {
                rentalDTO.AppUser = await _applicationUserService.GetCurrentUserAsync(HttpContext);
                rentalDTO.Car = await _carService.GetAsync(rentalDTO.CarId);

                if (ModelState.IsValid)
                {
                    await _rentalService.CreateAsync(rentalDTO);
                    return RedirectToAction(nameof(Index));
                }

                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            // return View(rentalDTO);
            return RedirectToAction("Rent");
        }
    }
}
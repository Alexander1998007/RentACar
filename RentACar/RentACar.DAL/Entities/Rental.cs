using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DAL.Entities
{
    public class Rental
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        [Required]
        [Display(Name = "Car")]
        public int CarId { get; protected set; }

        [Required]
        [Display(Name = "User")]
        public string AppUserId { get; protected set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start of rental")]
        public DateTime StartCarRentalDate { get; protected set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End of rental")]
        public DateTime EndCarRentalDate { get; protected set; }

        [Display(Name = "Price per day")]
        [Column(TypeName = "Money")]
        public decimal PricePerDay { get; protected set; }

        [Display(Name = "Full price")]
        [Column(TypeName = "Money")]
        public decimal FullPrice { get; protected set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; protected set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; protected set; }

        [Display(Name = "Length of rental (days)")]
        public int RentalInDays { get; protected set; }

        public Car Car { get; protected set; }
        public ApplicationUser AppUser { get; protected set; }

        private Rental() { }
        private Rental(int carId, string applicationUserId, DateTime startDate, DateTime endDate, decimal price)
        {
            //Id = Guid.NewGuid();

            // Setters
            SetCarId(carId);
            SetApplicationUserId(applicationUserId);
            SetPricePerDay(price);
            SetStartDate(startDate);
            SetEndDate(endDate);

            // Automatic properties
            var rentalInDays = CountRentalInDays(startDate, endDate);
            var fullPrice = CountFullPrice(price, rentalInDays);

            SetRentalInDays(rentalInDays);
            SetFullPrice(fullPrice);

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        private decimal CountFullPrice(decimal price, int rentalInDays)
        {
            if (price < 0)
            {
                throw new Exception("Price cannot be lower than 0.");
            }
            if (rentalInDays < 1)
            {
                throw new Exception("Days of rental cannot be shorter than one day.");
            }

            return price * rentalInDays;
        }

        private static int CountRentalInDays(DateTime startDate, DateTime endDate)
        {
            if (startDate == null)
            {
                throw new Exception("Start date cannot be empty.");
            }
            if (endDate == null)
            {
                throw new Exception("End date cannot be empty.");
            }

            return ((endDate - startDate).Days + 1);
        }

        private void SetRentalInDays(int rentalInDays)
        {
            if (StartCarRentalDate == null)
            {
                throw new Exception("Date of start of rental cannot be empty.");
            }
            if (EndCarRentalDate == null)
            {
                throw new Exception("Date of end of rental cannot be empty.");
            }
            if (RentalInDays == rentalInDays) return;

            RentalInDays = rentalInDays;
        }

        private void SetFullPrice(decimal price)
        {
            if (price < 0)
            {
                throw new Exception("Full price cannot be lower than 0.");
            }
            if (FullPrice == price) return;

            FullPrice = price;
        }

        private void SetStartDate(DateTime startDate)
        {
            if (StartCarRentalDate == startDate) return;
            StartCarRentalDate = startDate;
        }

        private void SetEndDate(DateTime endDate)
        {
            if (StartCarRentalDate != null && StartCarRentalDate < EndCarRentalDate)
            {
                throw new Exception("Rental end date cannot be earlier than rental start date.");
            }
            if (EndCarRentalDate == endDate) return;
            EndCarRentalDate = endDate;
        }

        private void SetPricePerDay(decimal price)
        {
            if (price < 0)
            {
                throw new Exception("Price cannot be lower than 0.");
            }
            if (PricePerDay == price) return;
            PricePerDay = price;
        }

        private void SetApplicationUserId(string appUserId)
        {
            if (appUserId == null)
            {
                throw new Exception("Application User Id cannot be null.");
            }
            if (AppUserId == appUserId) return;
            AppUserId = appUserId;
        }

        private void SetCarId(int carId)
        {
            if (carId == null)
            {
                throw new Exception("CarId cannot be null.");
            }
            if (CarId == carId) return;
            CarId = carId;
        }

        public static Rental Create(int carId, string appUserId,
            DateTime startDate, DateTime endDate, decimal price)
            => new Rental(carId, appUserId, startDate, endDate, price);
    }
}

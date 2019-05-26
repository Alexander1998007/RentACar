using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.BLL.DTO
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string AppUserId { get; set; }

        [Display(Name = "Start of rental")]
        public DateTime StartCarRentalDate { get; set; }

        [Display(Name = "End of rental")]
        public DateTime EndCarRentalDate { get; set; }

        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Full price")]
        public decimal FullPrice { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }

        [Display(Name = "Length of rental (days)")]
        public int RentalInDays { get; set; }

        public CarDTO Car { get; set; }
        public ApplicationUserDTO AppUser { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentACar.BLL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }

        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }

        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }
    }
}

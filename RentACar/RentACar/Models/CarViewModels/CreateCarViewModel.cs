using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models.CarViewModels
{
    public class CreateCarViewModel
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string RegistrationNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

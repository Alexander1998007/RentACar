using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DAL.Entities
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;  set; }

        [StringLength(17, MinimumLength = 17)]
        public string VIN { get;  set; }

        [Display(Name = "Registration Number")]
        [StringLength(10, MinimumLength = 3)]
        public string RegistrationNumber { get;  set; }

        [StringLength(50, MinimumLength = 1)]
        public string Brand { get;  set; }

        [StringLength(50, MinimumLength = 1)]
        public string Model { get;  set; }

        [Column(TypeName = "Money")]
        public decimal Price { get;  set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get;  set; }

        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }

        public Car() { }
        public Car(string vin, string registrationNumber,
            string brand, string model, decimal price)
        {
            //Id = Guid.NewGuid();
            SetVin(vin);
            SetRegistrationNumber(registrationNumber);
            SetBrand(brand);
            SetModel(model);
            SetPrice(price);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRegistrationNumber(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new Exception("Registration number cannot be empty.");
            }
            if (RegistrationNumber == registrationNumber) return;
            RegistrationNumber = registrationNumber;
        }

        public void SetVin(string vin)
        {
            if (string.IsNullOrWhiteSpace(vin))
            {
                throw new Exception("VIN cannot be empty.");
            }
            if (VIN == vin) return;
            VIN = vin;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new Exception("Price cannot be lower than 0.");
            }
            if (Price == price) return;
            Price = price;
        }

        public void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Brand cannot be empty.");
            }
            if (Brand == brand) return;
            Brand = brand;
        }

        public void SetModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new Exception("Model name cannot be empty.");
            }
            if (Model == model) return;
            Model = model;
        }

        public static Car Create(string vin, string registrationNumber,
            string brand, string model, decimal price)
            => new Car(vin, registrationNumber, brand, model, price);
    }
}

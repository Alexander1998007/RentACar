using System.Collections.Generic;

namespace RentACar.BLL.DTO
{
    public class ApplicationUserDTO
    {
        private ISet<RentalDTO> _rentals = new HashSet<RentalDTO>();

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<RentalDTO> Rentals
        {
            get { return _rentals; }
            set { _rentals = new HashSet<RentalDTO>(value); }
        }
    }
}

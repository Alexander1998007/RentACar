using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace RentACar.DAL.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Rental> Rentals { get; private set; }

        public ApplicationUser()
        {
            Rentals = new HashSet<Rental>();
        }
    }
}

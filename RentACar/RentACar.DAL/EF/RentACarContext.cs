using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Entities;

namespace RentACar.DAL.EF
{
    public class RentACarContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public RentACarContext(DbContextOptions<RentACarContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

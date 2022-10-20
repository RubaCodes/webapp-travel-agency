using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
    }
}
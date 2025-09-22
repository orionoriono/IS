using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicEShop.Domain.ExternalModels;

namespace MusicEShop.Repository
{
    public class ExternalDbContext : IdentityDbContext
    {
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<TravelPackage> TravelPackages { get; set; }
        public virtual DbSet<Itinerary> Itineraries { get; set; }

        public ExternalDbContext(DbContextOptions<ExternalDbContext> options)
          : base(options)
        { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Booking>().ToTable("Bookings"); 


            base.OnModelCreating(modelBuilder);
        }
    }
}

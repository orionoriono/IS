using Microsoft.EntityFrameworkCore;
using MusicEShop.Domain.DomainModels;
using MusicEShop.Domain.ExternalModels;
using MusicEShop.Repository.Interface;

namespace MusicEShop.Repository.Implementation
{
    public class BookingRepository : ExternalRepository<Booking>, IBookingRepository
    {
        private readonly ExternalDbContext context;
        private DbSet<Booking> entities;
        public BookingRepository(ExternalDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<Booking>();
        }

        public List<Booking> GetAllBookings()
        {
            return context.Bookings
                .Include(b => b.TravelPackage)
                .ToList();
        }

        //public Artist? GetArtistById(Guid id)
        //{
        //    return entities
        //        .Include(a => a.Albums)
        //        .Include(a => a.ArtistTracks!)
        //        .ThenInclude(at => at.Track)
        //        .SingleOrDefault(a => a.Id == id);
        //}

        //public List<Artist> GetArtistsWithAlbums()
        //{
        //    return context.Artists.Include(a => a.Albums).ToList();
        //}
    }
}

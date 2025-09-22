using MusicEShop.Domain.DomainModels;
using MusicEShop.Domain.ExternalModels;

namespace MusicEShop.Repository.Interface
{
    public interface IBookingRepository : IExternalRepository<Booking>
    {
        List<Booking> GetAllBookings();
     }
}

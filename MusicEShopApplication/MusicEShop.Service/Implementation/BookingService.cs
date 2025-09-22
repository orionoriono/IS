using MusicEShop.Domain.ExternalModels;
using MusicEShop.Repository.Interface;
using MusicEShop.Service.Interface;

namespace MusicEShop.Service.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

    
        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }
    }
}

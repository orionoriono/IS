using Microsoft.AspNetCore.Identity;

namespace MusicEShop.Domain.ExternalModels
{
    public class TravelAgencyUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }

    }       
 }
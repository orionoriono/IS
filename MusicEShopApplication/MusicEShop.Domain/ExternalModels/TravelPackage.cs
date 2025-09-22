using MusicEShop.Domain.DomainModels;

namespace MusicEShop.Domain.ExternalModels
{
    public class TravelPackage : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int NumberOfNights { get; set; }
        public string? Image { get; set; }
        public virtual DateTime DepartureDate { get; set; }
        public Guid? AccommodationId { get; set; }
        public virtual Accommodation? Accommodation { get; set; }
        public virtual ICollection<Itinerary>? Itineraries { get; set; }

    }
}
using MusicEShop.Domain.DomainModels;
using MusicEShop.Domain.ExternalModels.Enum;

namespace MusicEShop.Domain.ExternalModels
{
    public class Accommodation : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public AccommodationType? accommodationType { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxNumberOfRooms { get; set; }
        public virtual ICollection<TravelPackage>? TravelPackages { get; set; }

    }
}
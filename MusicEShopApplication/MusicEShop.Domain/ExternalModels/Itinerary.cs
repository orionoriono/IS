using MusicEShop.Domain.DomainModels;

namespace MusicEShop.Domain.ExternalModels
{
    public class Itinerary : BaseEntity
    {
        public string? Description { get; set; }
        public int DayNumber { get; set; }
        public Guid TravelPackageId { get; set; } // Foreign Key
        public virtual TravelPackage? TravelPackage { get; set; }

    }
}
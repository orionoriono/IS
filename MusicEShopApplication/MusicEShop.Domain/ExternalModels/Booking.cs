using MusicEShop.Domain.DomainModels;

namespace MusicEShop.Domain.ExternalModels
{

    public class Booking : BaseEntity {

        public int? NumberOfRooms { get; set; }
        public decimal? FullPrice { get; set; }

        public Guid? TravelPackageId { get; set; }

        public virtual TravelPackage? TravelPackage { get; set; }
        public virtual TravelAgencyUser? User { get; set; }
        public String? UserId { get; set; }

    }
}

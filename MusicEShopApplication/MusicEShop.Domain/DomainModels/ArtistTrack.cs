using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Domain.DomainModels
{
    public class ArtistTrack : BaseEntity
    {
        public Guid ArtistId { get; set; }
        public Artist? Artist { get; set; }

        public Guid TrackId { get; set; }
        public Track? Track { get; set; }
    }
}

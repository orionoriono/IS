using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Domain.DomainModels
{
    public class Artist : BaseEntity
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Genre { get; set; }
        public string? ArtistImage { get; set; }
        public  ICollection<Album>? Albums { get; set; }
        public virtual ICollection<ArtistTrack>? ArtistTracks { get; set; }
    }
}

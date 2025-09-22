using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicEShop.Domain.Identity;

namespace MusicEShop.Domain.DomainModels
{
    public class Playlist : BaseEntity
    {
        public string? Name { get; set; }

        // Foreign Key for User (One-to-Many)
        public string UserId { get; set; }
        public MusicEShopUser? User { get; set; }

        // Many-to-Many: Playlist ↔ Tracks
        public virtual ICollection<PlaylistTrack>? PlaylistTracks { get; set; }
    }
}

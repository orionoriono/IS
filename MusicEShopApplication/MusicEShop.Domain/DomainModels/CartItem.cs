using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Domain.DomainModels
{
    public class CartItem : BaseEntity
    {
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }

        public Guid? TrackId { get; set; }
        public Track? Track { get; set; }

        public Guid? AlbumId { get; set; }
        public Album? Album { get; set; }

        public int Quantity { get; set; }
    }
}
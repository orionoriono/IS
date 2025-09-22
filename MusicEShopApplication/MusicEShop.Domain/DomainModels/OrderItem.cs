using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Domain.DomainModels
{
    public class OrderItem : BaseEntity
    {
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid? TrackId { get; set; }
        public Track? Track { get; set; }

        public Guid? AlbumId { get; set; }
        public Album? Album { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
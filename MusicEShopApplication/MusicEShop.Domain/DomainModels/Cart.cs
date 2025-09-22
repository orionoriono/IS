using MusicEShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Domain.DomainModels
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; }
        public MusicEShopUser? User { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}

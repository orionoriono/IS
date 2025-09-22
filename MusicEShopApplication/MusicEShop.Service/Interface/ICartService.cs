using MusicEShop.Domain.DomainModels;
using MusicEShop.Domain.DTO;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Service.Interface
{
    public interface ICartService
    {
        CartDTO getShoppingCartInfo(string userId);
        bool DeleteItemFromShoppingCart(string userId, Guid albumId);
        SessionCreateOptions order(string userId);
        bool AddToShoppingConfirmed(CartItem model, string userId);
    }
}

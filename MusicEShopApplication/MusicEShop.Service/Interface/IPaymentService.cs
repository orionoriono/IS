using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicEShop.Domain.DomainModels;
using Stripe.Checkout;

namespace MusicEShop.Service.Interface
{
    public  interface IPaymentService
    {
        SessionCreateOptions CreateSessionOptions(List<OrderItem> orderedItems);
    }
}

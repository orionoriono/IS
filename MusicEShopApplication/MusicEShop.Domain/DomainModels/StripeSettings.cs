using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Domain.DomainModels
{
    public  class StripeSettings:BaseEntity
    {
        public string SecretKey {  get; set; }
        public string PublishableKey { get; set; }
    }
}

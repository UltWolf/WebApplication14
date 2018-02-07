using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.ConfigPaypal
{
    interface IBraintreeConfiguration
    {

            IBraintreeGateway CreateGateway();
            IBraintreeGateway GetGateway();
        }
    
}

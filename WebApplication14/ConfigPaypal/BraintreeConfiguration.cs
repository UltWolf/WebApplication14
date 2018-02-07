using Braintree;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApplication14.ConfigPaypal
{
    public class BraintreeConfiguration : IBraintreeConfiguration
    {
        public string Environment { get; set; }
        public string MerchantId { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        private IBraintreeGateway BraintreeGateway { get; set; }

        public IBraintreeGateway CreateGateway()
        {
            Environment = Braintree.Environment.SANDBOX.EnvironmentName;
            MerchantId = "8bjn5wqsywcwy49z";
            PublicKey = "4dsdczp3y934s87t";
            PrivateKey = "2d20a3f43d63fb14611430bdd8043559";

            if (MerchantId == null || PublicKey == null || PrivateKey == null)
            {
                Environment = Braintree.Environment.SANDBOX.EnvironmentName;
                MerchantId = "8bjn5wqsywcwy49z";
                PublicKey = "4dsdczp3y934s87t";
                PrivateKey = "2d20a3f43d63fb14611430bdd8043559";
            }

            return new BraintreeGateway(Environment, MerchantId, PublicKey, PrivateKey);
        }



        public IBraintreeGateway GetGateway()
        {
            if (BraintreeGateway == null)
            {
                BraintreeGateway = CreateGateway();
            }

            return BraintreeGateway;
        }
    }
}

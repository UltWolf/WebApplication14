using PayPal.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Helpers
{
    public class PaypalHelpers
    {

            public static LinkDescriptionObject findApprovalLink(List<LinkDescriptionObject> links)
            {
                foreach (var link in links)
                {
                    if (link.Rel.Equals("approval_url"))
                    {
                        return link;
                    }
                }
                return null;
            }
        
    }
}

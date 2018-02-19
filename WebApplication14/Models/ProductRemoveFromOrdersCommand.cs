using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class ProductRemoveFromOrdersCommand:BaseCommand
    {
        public readonly int OldProductID;
        public readonly int OrderID;

        public ProductRemoveFromOrdersCommand(Guid id, int oldProductsID, int orderID)
        {
            Id = id;
            OldProductID = oldProductsID;
            OrderID = orderID;
        }
    }
}

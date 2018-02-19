using System;

namespace WebApplication14.Models
{
    public class ProductsRemovedFromOrdersEvent:BaseEvent
    {
        public readonly int OldProductID;
        public readonly int OrderID;

        public ProductsRemovedFromOrdersEvent(Guid id, int oldProductsID, int orderID)
        {
            Id = id;
            OldProductID = oldProductsID;
            OrderID = orderID;
        }
    }
}

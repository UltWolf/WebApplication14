using System;


namespace WebApplication14.Models
{
    public class ProductsAssignedToOrderEvent:BaseEvent
    {
        public readonly int NewProductsID;
        public readonly int OrderID;

        public ProductsAssignedToOrderEvent(Guid id, int newProductsID, int orderID)
        {
            Id = id;
            NewProductsID = newProductsID;
            OrderID = orderID;
        }
    }
}

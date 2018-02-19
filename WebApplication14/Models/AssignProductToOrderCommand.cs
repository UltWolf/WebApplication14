using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class AssignProductToOrderCommand:BaseCommand
    {
        public readonly int NewProductsID;
        public readonly int OrderID;

        public AssignProductToOrderCommand(Guid id, int newProductsID, int orderID)
        {
            Id = id;
            NewProductsID = newProductsID;
            OrderID = orderID;
        }
    }
}

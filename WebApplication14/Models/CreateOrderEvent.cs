using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class CreateOrderEvent:BaseEvent
    {
        public readonly int OrderId;
        public readonly int IdProduct;
        public readonly Product Product;
        public readonly string Paymentid;
        public readonly DateTime DateOfOrder;
        public readonly string UserId;
        public readonly AppUser User;
        public readonly int Count;
        public readonly decimal TotalCost;
        public readonly bool IsConfirm;

        public CreateOrderEvent(System.Guid id, string userId, int count, bool isConfirm, decimal totalCost)
        {
            Id = id;
            this.IdProduct = this.Product.ProductId;
            this.DateOfOrder = DateTime.Now;
            this.UserId = userId;
            this.Count = count;
            this.TotalCost = totalCost;
            this.IsConfirm = isConfirm;
            
        }
    }
}

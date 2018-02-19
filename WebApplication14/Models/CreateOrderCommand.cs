using System;

namespace WebApplication14.Models
{
    public class CreateOrderCommand:BaseCommand
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
        public CreateOrderCommand(System.Guid id,Product product,string userId,int count, bool isConfirm, decimal totalCost)
        {
            Id = id;
            this.Product = product;
            this.IdProduct = this.Product.ProductId;
            this.DateOfOrder = DateTime.Now;
            this.UserId = userId;
            this.Count = count;
            this.TotalCost = totalCost;
            this.IsConfirm = isConfirm;

        }
    }
}

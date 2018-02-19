using System;


namespace WebApplication14.Models
{
    public class Order : CQRSlite.Domain.AggregateRoot
    {
        private int OrderId{ get; set; }
        private int IdProduct { get; set; }
        private System.Collections.Generic.List<int> Product { get; set; }
        private string Paymentid { get; set; }
        private DateTime DateOfOrder { get; set; }
        private string UserId { get; set; }
        private AppUser User { get; set; }
        private int Count { get; set; }
        private decimal TotalCost { get; set; }
        private bool IsConfirm { get; set; }
        public Order(System.Guid id, System.Collections.Generic.List<int> product, 
                     string userId, int count, bool isConfirm, decimal totalCost)
        {
            Id = id;
            this.Product = product;
            this.DateOfOrder = DateTime.Now;
            this.UserId = userId;
            this.Count = count;
            this.TotalCost = totalCost;
            this.IsConfirm = isConfirm;
            ApplyChange(new CreateOrderEvent(id,this.UserId,this.Count,this.IsConfirm,this.TotalCost));

        }
        public void AddProduct(int productId)
        {
            this.Product.Add(productId);
            ApplyChange(new ProductsAssignedToOrderEvent(Id, IdProduct, OrderId));
        }

        public void RemoveProduct(int productId)
        {
            this.Product.Remove(productId);
            ApplyChange(new ProductsRemovedFromOrdersEvent(Id, IdProduct, OrderId));
        }
    }
}

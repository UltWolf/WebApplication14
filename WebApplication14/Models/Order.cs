using System;


namespace WebApplication14.Models
{
    public class Order : CQRSlite.Domain.AggregateRoot
    {
        public int OrderId{ get; set; }
        public int IdProduct { get; set; }
        public System.Collections.Generic.List<int> Product { get; set; }
        public string Paymentid { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int Count { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsConfirm { get; set; }
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

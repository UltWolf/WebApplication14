using System;


namespace WebApplication14.Models
{
    public class Order
    {
        public int OrderId{ get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public int? Paymentid { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Count { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsConfirm { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class OrderRM
    {
        public int OrderId { get; set; }
        public int IdProduct { get; set; }
        public System.Collections.Generic.List<int> Product { get; set; }
        public string Paymentid { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int Count { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsConfirm { get; set; }
        public Guid AggregateID { get; set; }
        OrderRM()
        {
            Product = new List<int>();
        }
    }
}

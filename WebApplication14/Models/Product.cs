using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebApplication14.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public bool IsHave { get; set; }
        public string Path{get;set;}
        public ICollection<Order> Orders{get;set;}
    public Product()
    {
            Orders = new Collection<Order>();
    }

    }
}

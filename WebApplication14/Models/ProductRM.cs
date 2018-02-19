using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class ProductRM
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public bool IsHave { get; set; }
        public string Path { get; set; }
        public Guid AggregateID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models.ViewModel
{
    public class SearchModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal? Price { get; set; }
        public decimal? MinPrice { get; set; }
        public bool IsHave { get; set; }
    }
}

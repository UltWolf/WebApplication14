using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models.ViewModel
{
    public class ProductsModel
    {
        public  PaginationProductModel pgm { get; set; }
        public List<Product> products { get; set; }
    }
}

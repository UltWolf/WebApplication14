using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
   public interface IProductRepository:IBaseRepository<ProductRM>
    {
        IEnumerable<ProductRM> GetAll();
    }
}

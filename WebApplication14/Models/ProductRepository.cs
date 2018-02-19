using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class ProductRepository<T>:BaseRepository, IProductRepository
    {
        public ProductRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "product") { }


        public ProductRM GetByID(int productID)
        {
            return Get<ProductRM>(productID);
        }

        public List<ProductRM> GetMultiple(List<int> productIDs)
        {
            return GetMultiple<ProductRM>(productIDs);
        }

        public IEnumerable<ProductRM> GetAll()
        {
            return Get<List<ProductRM>>("all");
        }

        public void Save(ProductRM product)
        {
            Save(product.ProductId, product);
            MergeIntoAllCollection(product);
        }

        private void MergeIntoAllCollection(ProductRM product)
        {
            List<ProductRM> allProducts = new List<ProductRM>();
            if (Exists("all"))
            {
                allProducts = Get<List<ProductRM>>("all");
            }

            if (allProducts.Any(x => x.ProductId == product.ProductId))
            {
                allProducts.Remove(allProducts.First(x => x.ProductId == product.ProductId));
            }
           
            allProducts.Add(product);

            Save("all", allProducts);
        }


    }
}

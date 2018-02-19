using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication14.Models
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "order") { }


        public OrderRM GetByID(int orderID)
        {
            return Get<OrderRM>(orderID);
        }

        public List<OrderRM> GetMultiple(List<int> orderIDs)
        {
            return GetMultiple<OrderRM>(orderIDs);
        }

        public IEnumerable<OrderRM> GetAll()
        {
            return Get<List<OrderRM>>("all");
        }

        public void Save(OrderRM order)
        {
            Save(order.OrderId, order);
            MergeIntoAllCollection(order);
        }

        private void MergeIntoAllCollection(OrderRM order)
        {
            List<OrderRM> allOrders = new List<OrderRM>();
            if (Exists("all"))
            {
                allOrders = Get<List<OrderRM>>("all");
            }

            if (allOrders.Any(x => x.IdProduct == order.IdProduct))
            {
                allOrders.Remove(allOrders.First(x => x.IdProduct == order.IdProduct));
            }


            allOrders.Add(order);

            Save("all", allOrders);
        }

        public bool HasProducts(int OrderID, int productID)
        {
            var location = Get<OrderRM>(OrderID);

            return location.Product.Contains(productID);
        }

        public IEnumerable<ProductRM> GetProduct(int productID)
        {
            return Get<List<ProductRM>>(productID.ToString() + ":products");
        }
    }
}

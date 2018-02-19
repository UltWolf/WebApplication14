
namespace WebApplication14.Models
{
    public interface IOrderRepository:IBaseRepository<OrderRM>
    {
        System.Collections.Generic.IEnumerable<OrderRM> GetAll();
        System.Collections.Generic.IEnumerable<ProductRM> GetProduct(int productID);
        bool HasProducts(int orderID, int productID);
    }
}

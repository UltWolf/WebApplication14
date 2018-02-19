
namespace WebApplication14.Models
{
    public class Product:CQRSlite.Domain.AggregateRoot
    {
        private int ProductId { get; set; }
        private string Category { get; set; }
        private string Name { get; set; }
        private string Country { get; set; }
        private decimal Price { get; set; }
        private bool IsHave { get; set; }
        private string Path { get; set; }

        public Product(System.Guid id,  string category, string name, string country, decimal price, bool isHave, string path)
        {
            Id = id;
            this.Price = price;
            this.Path = path;
            this.Country = country;
            this.IsHave = isHave;
            this.Category = category;
            ApplyChange(new CreateProductEvent(id,category,name,country, price,isHave, path));

        }
    }
}

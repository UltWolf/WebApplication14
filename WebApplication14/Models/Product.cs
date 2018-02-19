
namespace WebApplication14.Models
{
    public class Product:CQRSlite.Domain.AggregateRoot
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public bool IsHave { get; set; }
        public string Path { get; set; }

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

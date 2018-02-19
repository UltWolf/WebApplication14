using System;

namespace WebApplication14.Models
{
    public class CreateProductEvent:BaseEvent
    {
        public readonly int ProductId;
        public readonly string Category;
        public readonly string Name;
        public readonly string Country;
        public readonly decimal Price;
        public readonly bool IsHave;
        public readonly string Path;

        public CreateProductEvent(System.Guid id, string category, string name, string country, decimal price, bool isHave, string path)
        {
            Id = id;
            this.Price = price;
            this.Path = path;
            this.Country = country;
            this.IsHave = isHave;
            this.Category = category;

        }
    }
}

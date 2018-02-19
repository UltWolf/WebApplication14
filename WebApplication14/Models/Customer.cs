
namespace WebApplication14.Models
{
    public class Customer: CQRSlite.Domain.AggregateRoot
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  
        public string Location { get; set; }
    }
}

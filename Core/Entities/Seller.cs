using ConsoleCommerceApp.Core.Entities;
namespace Core.Entities
{
    public class Seller : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string SerialNumber { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

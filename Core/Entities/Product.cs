using ConsoleCommerceApp.Core.Entities;
namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public Category Category { get; set; }
        public Seller Seller { get; set; }
    }
}

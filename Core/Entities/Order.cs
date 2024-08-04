using ConsoleCommerceApp.Core.Entities;
namespace Core.Entities
{
    public class Order : BaseEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
    }
}

using Core.Entities;

namespace Application.Services.Abstract
{
    public interface ISellerService
    {
        void AddProduct();
        void UpdateProduct(int productId);
        void DeleteProduct(int productId);
        void GetProduct(int productId);
        void GetProductsByDate(DateTime date);
        void GetProducts();
        void GetIncome();
    }
}

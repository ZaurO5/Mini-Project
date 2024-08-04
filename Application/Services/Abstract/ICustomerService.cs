using Core.Entities;

namespace Application.Services.Abstract
{
    public interface ICustomerService
    {
        void BuyProduct(int customerId);
        void ViewProducts();
        void ViewProductsByDate(DateTime date);
        void SearchProducts();
    }
}

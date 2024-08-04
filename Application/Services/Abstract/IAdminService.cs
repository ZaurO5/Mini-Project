using ConsoleCommerceApp.Core.Entities;
using Core.Entities;
namespace Application.Services.Abstract
{
        public interface IAdminService
        {
        void GetAllCustomers();
        void GetAllSellers();
        void GetOrders();
        void GetSellerOrders();
        void GetCustomerOrders();
        void GetOrdersByDate();
        void AddCustomer();
        void AddSeller();
        void UpdateCustomer(int id);
        void UpdateSeller(int id);
        void RemoveCustomer(int id);
        void RemoveSeller(int id);
        }
}

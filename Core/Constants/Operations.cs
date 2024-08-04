using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants;

public enum AdminServiceOperations
{
    Exit,
    ShowAllCustomers,
    ShowAllSellers,
    ShowAllOrders,
    ShowOrderByDate,
    ShowCustomerOrder,
    ShowSellerOrder,
    AddCustomer,
    AddSeller,
    AddCategory,
    DeleteCustomer,
    DeleteSeller,
    DeleteCategory,
    LoginMenu,
    UpdateCustomer,
    UpdateSeller
}
public enum CustomerServiceOperations
{
    Exit,
    BuyProduct,
    ViewProducts,
    ViewProductsByDate,
    SearchProducts,
    LoginMenu
}

public enum SellerServiceOperations
{
    Exit,
    AddProduct,
    UpdateProduct,
    DeleteProduct,
    GetProduct,
    GetProductsByDate,
    GetProducts,
    GetIncome,
    LoginMenu
}

using Application.Services.Concrete;
using Core.Constants;
using Data;
using System;

namespace ConsoleCommerceApp;

public static class Program
{
    private static readonly AdminService _adminService;
    private static readonly CustomerService _customerService;
    private static readonly SellerService _sellerService;

    static Program()
    {
        var context = new ApplicationDbContext();
        _adminService = new AdminService();
        _customerService = new CustomerService(context);
        _sellerService = new SellerService(context);
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            LoginMenu();
        }
    }

    public static void LoginMenu()
    {
        Console.Clear();
        Console.WriteLine("Select your profile:");
        Console.WriteLine("0. Admin");
        Console.WriteLine("1. Customer");
        Console.WriteLine("2. Seller");

        string profileInput = Console.ReadLine();
        int profileOption;
        bool isProfileOptionValid = int.TryParse(profileInput, out profileOption);

        if (!isProfileOptionValid || profileOption < 0 || profileOption > 2)
        {
            Messages.InvalidInputMessage("Profile");
            return;
        }

        switch (profileOption)
        {
            case 0:
                AdminMenu();
                break;
            case 1:
                CustomerMenu();
                break;
            case 2:
                SellerMenu();
                break;
            default:
                Messages.InvalidInputMessage("Profile");
                break;
        }
    }

    public static void AdminMenu()
    {
        while (true)
        {
           
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Show All Customers");
            Console.WriteLine("2. Show All Sellers");
            Console.WriteLine("3. Show All Orders");
            Console.WriteLine("4. Show Order By Date");
            Console.WriteLine("5. Show Customer's Orders");
            Console.WriteLine("6. Show Seller's Orders");
            Console.WriteLine("7. Add Customer");
            Console.WriteLine("8. Add Seller");
            Console.WriteLine("9. Delete Customer");
            Console.WriteLine("10. Delete Seller");
            Console.WriteLine("11. Delete Category");
            Console.WriteLine("12. Login Menu");

            string optionInput = Console.ReadLine();
            int option;
            bool isTrueOption = int.TryParse(optionInput, out option);

            if (!isTrueOption || !Enum.IsDefined(typeof(AdminServiceOperations), option))
            {
                Messages.InvalidInputMessage("Option");
                continue;
            }

            var adminOption = (AdminServiceOperations)option;

            switch (adminOption)
            {
                case AdminServiceOperations.ShowAllCustomers:
                    _adminService.GetAllCustomers();
                    break;
                case AdminServiceOperations.ShowAllSellers:
                    _adminService.GetAllSellers();
                    break;
                case AdminServiceOperations.ShowAllOrders:
                    _adminService.GetOrders();
                    break;
                case AdminServiceOperations.ShowOrderByDate:
                    _adminService.GetOrdersByDate();
                    break;
                case AdminServiceOperations.ShowCustomerOrder:
                    _adminService.GetCustomerOrders();
                    break;
                case AdminServiceOperations.ShowSellerOrder:
                    _adminService.GetSellerOrders();
                    break;
                case AdminServiceOperations.AddCustomer:
                    _adminService.AddCustomer();
                    break;
                case AdminServiceOperations.AddSeller:
                    _adminService.AddSeller();
                    break;
                case AdminServiceOperations.UpdateCustomer:
                    Console.WriteLine("Enter Customer ID to update:");
                    if (int.TryParse(Console.ReadLine(), out int customerId))
                    {
                        _adminService.UpdateCustomer(customerId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Customer ID");
                    }
                    break;
                case AdminServiceOperations.UpdateSeller:
                    Console.WriteLine("Enter Seller ID to update:");
                    if (int.TryParse(Console.ReadLine(), out int sellerId))
                    {
                        _adminService.UpdateSeller(sellerId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Seller ID");
                    }
                    break;
                case AdminServiceOperations.DeleteCustomer:
                    Console.WriteLine("Enter Customer ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteCustomerId))
                    {
                        _adminService.RemoveCustomer(deleteCustomerId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Customer ID");
                    }
                    break;
                case AdminServiceOperations.DeleteSeller:
                    Console.WriteLine("Enter Seller ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteSellerId))
                    {
                        _adminService.RemoveSeller(deleteSellerId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Seller ID");
                    }
                    break;
                case AdminServiceOperations.Exit:
                    Environment.Exit(0);
                    break;
                case AdminServiceOperations.LoginMenu:
                    return;
                default:
                    Messages.InvalidInputMessage("Option");
                    break;
            }
        }
    }

    public static void CustomerMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Customer Menu:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Buy Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. View Products By Date");
            Console.WriteLine("4. Search Products");
            Console.WriteLine("5. Login Menu");

            string optionInput = Console.ReadLine();
            int option;
            bool isTrueOption = int.TryParse(optionInput, out option);

            if (!isTrueOption || !Enum.IsDefined(typeof(CustomerServiceOperations), option))
            {
                Messages.InvalidInputMessage("Option");
                continue;
            }

            var customerOption = (CustomerServiceOperations)option;

            switch (customerOption)
            {
                case CustomerServiceOperations.BuyProduct:
                    Console.WriteLine("Enter Product ID to buy:");
                    if (int.TryParse(Console.ReadLine(), out int productId))
                    {
                        _customerService.BuyProduct(productId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Product ID");
                    }
                    break;
                case CustomerServiceOperations.ViewProducts:
                    _customerService.ViewProducts();
                    break;
                case CustomerServiceOperations.ViewProductsByDate:
                    Console.WriteLine("Enter date (YYYY-MM-DD):");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        _customerService.ViewProductsByDate(date);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Date");
                    }
                    break;
                case CustomerServiceOperations.SearchProducts:
                    Console.WriteLine("Enter search term:");
                    string searchTerm = Console.ReadLine();
                    _customerService.SearchProducts();
                    break;
                case CustomerServiceOperations.Exit:
                    Environment.Exit(0);
                    break;
                case CustomerServiceOperations.LoginMenu:
                    return;
                default:
                    Messages.InvalidInputMessage("Option");
                    break;
            }
        }
    }

    public static void SellerMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Seller Menu:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Get Product");
            Console.WriteLine("5. Get Products By Date");
            Console.WriteLine("6. Get Products");
            Console.WriteLine("7. Get Income");
            Console.WriteLine("8. Login Menu");

            string optionInput = Console.ReadLine();
            int option;
            bool isTrueOption = int.TryParse(optionInput, out option);

            if (!isTrueOption || !Enum.IsDefined(typeof(SellerServiceOperations), option))
            {
                Messages.InvalidInputMessage("Option");
                continue;
            }

            var sellerOption = (SellerServiceOperations)option;

            switch (sellerOption)
            {
                case SellerServiceOperations.AddProduct:
                    Console.WriteLine("Enter Product ID to add:");
                    if (int.TryParse(Console.ReadLine(), out int productId))
                    {
                        _sellerService.AddProduct();
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Product ID");
                    }
                    break;
                case SellerServiceOperations.UpdateProduct:
                    Console.WriteLine("Enter Product ID to update:");
                    if (int.TryParse(Console.ReadLine(), out int updateProductId))
                    {
                        _sellerService.UpdateProduct(updateProductId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Product ID");
                    }
                    break;
                case SellerServiceOperations.DeleteProduct:
                    Console.WriteLine("Enter Product ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteProductId))
                    {
                        _sellerService.DeleteProduct(deleteProductId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Product ID");
                    }
                    break;
                case SellerServiceOperations.GetProduct:
                    Console.WriteLine("Enter Product ID to get:");
                    if (int.TryParse(Console.ReadLine(), out int getProductId))
                    {
                        _sellerService.GetProduct(getProductId);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Product ID");
                    }
                    break;
                case SellerServiceOperations.GetProductsByDate:
                    Console.WriteLine("Enter date (YYYY-MM-DD):");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        _sellerService.GetProductsByDate(date);
                    }
                    else
                    {
                        Messages.InvalidInputMessage("Date");
                    }
                    break;
                case SellerServiceOperations.GetProducts:
                    _sellerService.GetProducts();
                    break;
                case SellerServiceOperations.GetIncome:
                    _sellerService.GetIncome();
                    break;
                case SellerServiceOperations.Exit:
                    Environment.Exit(0);
                    break;
                case SellerServiceOperations.LoginMenu:
                    return;
                default:
                    Messages.InvalidInputMessage("Option");
                    break;
            }
        }
    }
}

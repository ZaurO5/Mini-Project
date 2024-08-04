using Application.Services.Abstract;
using Core.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Services.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService()
        {
            _context = new ApplicationDbContext();
        }

        public void GetAllCustomers()
        {
            try
            {
                foreach (var customer in _context.Customers)
                {
                    Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getting CustomerList: {ex.Message}");
            }
        }



        public void GetAllSellers()
        {
            try
            {
                var sellers = _context.Sellers.ToList();
                foreach (var seller in sellers)
                {
                    Console.WriteLine($"Seller ID: {seller.Id}, Name: {seller.Name}, Email: {seller.Email}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in getting SellerList.");
            }
        }

        public void GetOrders()
        {
            try
            {
                var orders = _context.Orders
                    .Include(o => o.Product)
                    .Include(o => o.Customer)
                    .Include(o => o.Seller)
                    .ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Product: {order.Product.Name}, Customer: {order.Customer.Name}, Seller: {order.Seller.Name}, Quantity: {order.Quantity}, Total Amount: {order.TotalAmount}, Date: {order.OrderDate}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in getting orders.");
            }
        }

        public void GetSellerOrders()
        {
            try
            {
                var orders = _context.Orders
                    .Include(o => o.Product)
                    .Include(o => o.Customer)
                    .Include(o => o.Seller)
                    .ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Product: {order.Product.Name}, Seller: {order.Seller.Name}, Quantity: {order.Quantity}, Total Amount: {order.TotalAmount}, Date: {order.OrderDate}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in getting seller orders.");
            }
        }

        public void GetCustomerOrders()
        {
            try
            {
                var orders = _context.Orders
                    .Include(o => o.Product)
                    .Include(o => o.Customer)
                    .Include(o => o.Seller)
                    .ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Product: {order.Product.Name}, Customer: {order.Customer.Name}, Quantity: {order.Quantity}, Total Amount: {order.TotalAmount}, Date: {order.OrderDate}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in getting customer orders.");
            }
        }

        public void GetOrdersByDate()
        {
            try
            {
                Console.WriteLine("Enter date (YYYY-MM-DD):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    var orders = _context.Orders
                        .Include(o => o.Product)
                        .Include(o => o.Customer)
                        .Include(o => o.Seller)
                        .Where(o => o.OrderDate.Date == date.Date)
                        .ToList();

                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.Id}, Product: {order.Product.Name}, Customer: {order.Customer.Name}, Seller: {order.Seller.Name}, Quantity: {order.Quantity}, Total Amount: {order.TotalAmount}, Date: {order.OrderDate}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in getting orders by date.");
            }
        }

        public void AddCustomer()
        {
            
                Console.WriteLine("Enter Customer Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Customer Email:");
                string email = Console.ReadLine();

                Console.WriteLine("Enter Customer Password:");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("All fields are required.");
                    return;
                }

                if (password.Length < 8)
                {
                    Console.WriteLine("Password must be at least 8 characters long.");
                    return;
                }
            try
            {

                _context.SaveChanges();

                Console.WriteLine("Customer added successfully.");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in adding customer.");
            }
        }

        public void AddSeller()
        {
            try
            {
                Console.WriteLine("Enter Seller Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Seller Email:");
                string email = Console.ReadLine();

                Console.WriteLine("Enter Seller Password:");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("All fields are required.");
                    return;
                }

                if (password.Length < 8)
                {
                    Console.WriteLine("Password must be at least 8 characters long.");
                    return;
                }
                _context.SaveChanges();

                Console.WriteLine("Seller added successfully.");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in adding seller.");
            }
        }

        public void UpdateCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer != null)
                {
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                    Console.WriteLine("Customer updated successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in updating customer.");
            }
        }

        public void UpdateSeller(int id)
        {
            try
            {
                var seller = _context.Sellers.Find(id);
                if (seller != null)
                {
                    _context.Sellers.Update(seller);
                    _context.SaveChanges();
                    Console.WriteLine("Seller updated successfully.");
                }
                else
                {
                    Console.WriteLine("Seller not found.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in updating seller.");
            }
        }

        public void RemoveCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    Console.WriteLine("Customer removed successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in removing customer.");
            }
        }

        public void RemoveSeller(int id)
        {
            try
            {
                var seller = _context.Sellers.Find(id);
                if (seller != null)
                {
                    _context.Sellers.Remove(seller);
                    _context.SaveChanges();
                    Console.WriteLine("Seller removed successfully.");
                }
                else
                {
                    Console.WriteLine("Seller not found.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in removing seller.");
            }
        }
    }
}

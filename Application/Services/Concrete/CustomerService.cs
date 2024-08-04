using Application.Services.Abstract;
using Core.Entities;
using Data;
using System;
using System.Globalization;
using System.Linq;

namespace Application.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BuyProduct(int customerId)
        {
            try
            {
                Console.WriteLine("Enter Product ID:");
                int productId = int.Parse(Console.ReadLine());

                var product = _context.Products.Find(productId);
                if (product != null && product.Quantity > 0)
                {
                    var order = new Order
                    {
                        CustomerId = customerId,
                        ProductId = productId,
                        Quantity = 1,
                        TotalAmount = product.Price,
                        OrderDate = DateTime.Now
                    };

                    product.Quantity -= 1;
                    _context.Products.Update(product);
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    Console.WriteLine("Product purchased successfully.");
                }
                else
                {
                    Console.WriteLine("Product not available.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error buying product.");
            }
        }

        public void ViewProducts()
        {
            try
            {
                var products = _context.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in viewing products.");
            }
        }

        public void ViewProductsByDate(DateTime date)
        {
            try
            {
                var products = _context.Products
                    .Where(p => p.CreatedAt.Date == date.Date)
                    .ToList();

                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in viewing products by date.");
            }
        }

        public void SearchProducts()
        {
            try
            {
                var products = _context.Products.ToList();

                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in searching products.");
            }
        }

    }
}


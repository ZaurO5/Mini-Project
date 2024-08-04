using Application.Services.Abstract;
using Core.Entities;
using Data;
using System;
using System.Globalization;
using System.Linq;

namespace Application.Services.Concrete
{
    public class SellerService : ISellerService
    {
        private readonly ApplicationDbContext _context;

        public SellerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Product Price:");
                decimal price = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Enter Product Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                Console.WriteLine("Product added successfully.");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in adding product.");
            }
        }

        public void UpdateProduct(int productId)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in updating product.");
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in deleting product.");
            }
        }

        public void GetProduct(int productId)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error getting product.");
            }
        }

        public void GetProductsByDate(DateTime date)
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
                Console.WriteLine($"Error in getting products by date.");
            }
        }

        public void GetProducts()
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
                Console.WriteLine($"Error in getting products.");
            }
        }

        public void GetIncome()
        {
            try
            {
                var income = _context.Orders
                    .Sum(o => o.TotalAmount);

                Console.WriteLine($"Total Income: {income}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in getting income.");
            }
        }

    }
}

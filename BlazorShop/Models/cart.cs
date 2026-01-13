/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace BlazorShop.Models
{
    public class Cart
    {
        public List<Product> Products { get; private set; } = new List<Product>();

        // Ideally, keep credentials secure in a real app
        private string connString = "Server=localhost;Database=Shop;User ID=root;Password=password;";

        // 1. Add Product (Async + Database)
        public async Task AddProductAsync(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"[Memory] Added {product.Name} to cart.");

            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    await conn.OpenAsync();
                    string query = "INSERT INTO Products (ProductID, Name, Price, Category) VALUES (@Id, @Name, @Price, @Cat)";
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", product.ID);
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@Cat", product.Category);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                Console.WriteLine("[Database] Saved to MySQL.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Database Warning] Browser restricted DB access: {ex.Message}");
            }
        }

        // 2. Remove Product
        public void RemoveProduct(int productId)
        {
            var item = Products.FirstOrDefault(p => p.ID == productId);
            if (item != null)
            {
                Products.Remove(item);
            }
        }

        // 3. Checkout (Creates Order & Clears Cart)
        public async Task<Order> CheckoutAsync()
        {
            if (Products.Count == 0) throw new InvalidOperationException("Cart is empty");

            var newOrder = new Order
            {
                OrderId = new Random().Next(1000, 9999),
                OrderDate = DateTime.Now,
                TotalAmount = CalculateTotal(),
                Items = new List<Product>(Products)
            };

            // Database Save Logic for Order...
            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    await conn.OpenAsync();
                    // Example query: INSERT INTO Orders...
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"[Database Warning] {ex.Message}");
            }

            Products.Clear();
            return newOrder;
        }

        public decimal CalculateTotal() => Products.Sum(p => p.Price);
    }
} */
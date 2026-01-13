using BlazorShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorShop.Services
{
    public class ProductService
    {
        // This simulates your database table
        public List<Product> Products { get; private set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Gucci Bag", Price = 4500.00m, ImageUrl = "images/gucci.png", Category = "Fashion" },
            new Product { Id = 2, Name = "Face Cream", Price = 300.00m, ImageUrl = "images/cream.png", Category = "Beauty" },
            new Product { Id = 3, Name = "DSLR Camera", Price = 35000.00m, ImageUrl = "images/camera.png", Category = "Electronics" },
            new Product { Id = 4, Name = "Blue Shoes", Price = 910.00m, ImageUrl = "images/shoes.png", Category = "Footwear" },
            new Product { Id = 5, Name = "Leather Wallet", Price = 600.00m, ImageUrl = "images/wallet.png", Category = "Accessories" }
        };

        public List<Product> GetProducts()
        {
            return Products;
        }

        public Product? GetProductById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
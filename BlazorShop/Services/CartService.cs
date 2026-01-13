using BlazorShop.Models;
using System;
using System.Collections.Generic;

namespace BlazorShop.Services
{
    public class CartService
    {
        public List<Product> CartItems { get; private set; } = new List<Product>();
        
        // Make this nullable (?) to prevent warnings
        public event Action? OnChange;

        public void AddToCart(Product product)
        {
            CartItems.Add(product);
            NotifyStateChanged();
        }

        // --- NEW: Remove Feature ---
        public void RemoveFromCart(Product product)
        {
            CartItems.Remove(product);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
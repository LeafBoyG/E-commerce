using BlazorShop.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorShop.Services
{
    public class CartService
    {
        private readonly IJSRuntime _jsRuntime;

        // We inject JS Runtime to talk to the browser
        public CartService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public List<Product> CartItems { get; private set; } = new List<Product>();
        
        public event Action? OnChange;

        // --- 1. LOAD DATA ---
        public async Task LoadCartAsync()
        {
            try
            {
                // Ask browser for data
                var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "cart");
                
                if (!string.IsNullOrEmpty(json))
                {
                    CartItems = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
                    NotifyStateChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading cart: {ex.Message}");
            }
        }

        // --- 2. SAVE DATA ---
        private async void SaveCart()
        {
            try
            {
                var json = JsonSerializer.Serialize(CartItems);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "cart", json);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error saving cart: {ex.Message}");
            }
        }

        public void AddToCart(Product product)
        {
            CartItems.Add(product);
            SaveCart(); // Auto-save
            NotifyStateChanged();
        }

        public void RemoveFromCart(Product product)
        {
            CartItems.Remove(product);
            SaveCart(); // Auto-save
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
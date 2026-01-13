namespace BlazorShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        
        // This line fixes the error in ProductCard.razor
        public string Category { get; set; } = "General"; 
    }
}
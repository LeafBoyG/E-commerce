using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Models
{
    public class OrderDetails
    {
        // 1. Prevent scripts by only allowing letters, spaces, and simple punctuation
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s\.\-']+$", ErrorMessage = "Name contains invalid characters.")]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = string.Empty;

        // 2. Strict Address Validation
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 100 characters.")]
        public string Address { get; set; } = string.Empty;

        // 3. Email Validation (Built-in is good, but we ensure it's not too long)
        [Required, EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
    }
}
using System;
using System.Collections.Generic;

namespace BlazorShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Product> Items { get; set; } = new List<Product>();

        public string GetSummary()
        {
            return $"Order #{OrderId} | Date: {OrderDate} | Total: ${TotalAmount:F2}";
        }
    }
}
﻿namespace RapidBootcamp.WebApplication.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public IEnumerable<Product> Products { get; set; }
    }
}

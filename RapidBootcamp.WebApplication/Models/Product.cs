using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidBootcamp.WebApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        
        public Category? Category { get; set; }
    }
}
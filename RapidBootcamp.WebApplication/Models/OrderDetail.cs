using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidBootcamp.WebApplication.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public Product Product { get; set; }
    }
}
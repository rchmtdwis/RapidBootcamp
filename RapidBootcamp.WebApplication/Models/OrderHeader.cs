using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidBootcamp.WebApplication.Models
{
    public class OrderHeader
    {
        public string OrderHeaderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }

        public Customer Customer { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidBootcamp.WebApplication.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set;}
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public IEnumerable<OrderHeader> OrderHeaders { get; set; }
        
    }
}
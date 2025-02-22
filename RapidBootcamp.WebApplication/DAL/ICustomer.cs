using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public interface ICustomer : ICrud<Customer>
    {
        IEnumerable<Customer> GetCustomersByNameOrCity(string searchStr);
    }
}
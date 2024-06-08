using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public interface IProduct:ICrud<Product>
    {
        IEnumerable<Product> GetByCategoryId(int categoryId);
        IEnumerable<Product> GetByCategoryName(string categoryName);
        IEnumerable<Product> GetProductWithCategory();
    }
}
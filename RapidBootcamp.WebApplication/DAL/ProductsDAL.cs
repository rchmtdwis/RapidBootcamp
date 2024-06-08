using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class ProductsDAL : IProduct
    {
        private readonly IConfiguration _configuration;
        public ProductsDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string GetConStr()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            using(SqlConnection comn = new SqlConnection(GetConStr()));
            List<Product> products = new List<Product>();
            return products;
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductWithCategory()
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
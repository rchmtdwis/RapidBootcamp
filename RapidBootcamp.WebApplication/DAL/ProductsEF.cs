using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    
    public class ProductsEF : IProduct
    {
        private readonly AppDbContext _dbContext;

        public ProductsEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product entity)
        {
            _dbContext.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _dbContext.Products.Include(p=> p.Category).ToList();
            return products;
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            var product = _dbContext.Products.Include(p=> p.Category).Where(p=> p.Category.CategoryId == categoryId).ToList();
            return product;
        }

        public IEnumerable<Product> GetByCategoryName(string categoryName)
        {
            var product = _dbContext.Products.Include(p => p.Category).Where(p => p.Category.CategoryName.Contains(categoryName)).ToList();
            return product;
        }

        public Product GetById(int id)
        {
            var product = _dbContext.Products.Include(c=>c.Category).Where(x=> x.ProductId == id).FirstOrDefault();

            return product;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    

    public class CategoriesEF : ICategory
    
    {
        private readonly AppDbContext _dbContext;
        
        public CategoriesEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category Add(Category entity)
        {
            var data = new Category
            {
                CategoryName = entity.CategoryName
            };

            _dbContext.Categories.Add(data);
            _dbContext.SaveChanges();

            return data;
        }

        public void Delete(int id)
        {
           
            // var data = _dbContext.Categories.Where(x => x.CategoryId == id);
            var category = GetById(id);
            if(category != null)
            {
                _dbContext.RemoveRange(category);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Category not found");
            }
        }

        public IEnumerable<Category> GetAll()
        {
            var result = _dbContext.Categories.ToList();
            //var result = from c in _dbContext.Categories select c;
            return result;
        }

        public IEnumerable<Category> GetByCategoryName(string categoryName)
        {
            try
            {
                var category = _dbContext.Categories.Where(x => x.CategoryName.Contains(categoryName)).ToList();
                return category;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public Category GetById(int id)
        {
            // var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            var category = from c in _dbContext.Categories 
                            where c.CategoryId == id select c;
            
            return category.FirstOrDefault();
        }

        public Category Update(Category entity)
        {
            // var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == entity.CategoryId);
            var category = GetById(entity.CategoryId);
            if(category != null)
            {
                category.CategoryName = entity.CategoryName ?? category.CategoryName;
                _dbContext.SaveChanges();
            }

            return entity;
        }
    }
}
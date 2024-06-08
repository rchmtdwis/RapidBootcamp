
using System.Data.SqlClient;
using Dapper;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CategoriesDAL : ICategory
    {
        private readonly IConfiguration _configuration;
        public CategoriesDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string GetConStr()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
        public void Delete(int id)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                    string query = @"DELETE from categories where CategoryId=@CategoryId";
                    var param = new{CategoryId = id};
                    conn.Execute(query,param);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"select * from Categories order by CategoryName ASC";
                
                var categories = conn.Query<Category>(query);

                return categories;
            }
        }

        public Category GetById(int id)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = $@"select * from categories where CategoryId = @CategoryId";
                var param = new {CategoryId  = id};
                var category = conn.QuerySingleOrDefault<Category>(query, param);
                
                if(category == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }
                return category;

                throw new NotImplementedException();
            }
        }

        public Category Update(Category entity)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"UPDATE Categories SET CategoryName=@CategoryName 
                                WHERE CategoryId=@CategoryId";
                var param = new {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName
                };
                conn.Execute(query, param);
                return entity;
            }
            
        }

        public Category Add(Category entity)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"insert into Categories(CategoryName)
                                 values(@CategoryName);select @@identity";
                    var param = new { CategoryName = entity.CategoryName };
                    int newId = conn.ExecuteScalar<int>(query, param);
                    entity.CategoryId = newId;
                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    
                    throw new ArgumentException(sqlEx.Message);
                }
            }
        }

        public IEnumerable<Category> GetByCategoryName(string categoryName)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"Select * from Categories 
                            where CategoryName like @CategoryName 
                            order by CategoryName ASC";
                var param = new {CategoryName = $"%{categoryName}%"};
                
                var categories = conn.Query<Category>(query, param);

                return categories;
            }
        }
    }
}
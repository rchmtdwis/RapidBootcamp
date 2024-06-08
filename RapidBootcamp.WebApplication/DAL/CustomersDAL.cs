using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersDAL : ICustomer
    {
        private readonly IConfiguration _configuration;
        
        public CustomersDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConStr()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public Customer Add(Customer entity)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"insert into Customers(CustomerName,Address,City,Email,PhoneNumber) 
                                    values(@CustomerName,@Address,@City,@Email,@PhoneNumber);select @@identity";
                var param = new{
                    CustomerName = entity.CustomerName,
                    Address = entity.Address,
                    City = entity.City,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber
                };
                int newId = conn.ExecuteScalar<int>(query, param);
                entity.CustomerId = newId;

                return entity;
                }
                catch (SqlException sqlEx)
                {
                    
                    throw new ArgumentException(sqlEx.Message);
                }
                
    
            }
            
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"Delete from Customers where CustomerId = @CustomerId";
                    var param = new{CustomerId = id};
                    conn.Execute(query, param);
                }
                catch (Exception ex)
                {
                    
                    throw new Exception(ex.Message);
                }
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"select * from Customers order by CustomerName ASC";
                var categories = conn.Query<Customer>(query);
                
                return categories;
            }
        }

        public Customer GetById(int id)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"select * from Customers Where CustomerId = @CustomerId";
                var param = new {
                    CustomerId = id
                };
                var customer = conn.QuerySingleOrDefault<Customer>(query, param);
                if(customer == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }

                return customer;
            }
        }

        public Customer Update(Customer entity)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"UPDATE Customers
                                SET CustomerName=@CustomerName,Address=@Address,City=@City,
                                Email=@Email,PhoneNumber=@PhoneNumber 
                                WHERE CustomerId=@CustomerId";
                var param = new {
                    CustomerId = entity.CustomerId,
                    CustomerName = entity.CustomerName,
                    Address = entity.Address,
                    City = entity.City,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber,
                };
                conn.Execute(query, param);
                return entity;

            }
        }

        public IEnumerable<Customer> GetCustomersByNameOrCity(string searchStr)
        {
            using(SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers
                                WHERE CustomerName LIKE @searchStr OR City LIKE @searchStr;";

                var param = new {SearchStr = searchStr};
                var customers = conn.Query<Customer>(query,param);

                return customers;
            }
        }
    }
}
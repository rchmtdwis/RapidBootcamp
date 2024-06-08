using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersEF : ICustomer
    {
        private readonly AppDbContext _dbContext;

        public CustomersEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Customer Add(Customer entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            // var customer = _dbContext.Customers.FirstOrDefault(x => x.CustomerId == x.CustomerId);
            var customer = GetById(id);

            if(customer != null){
                _dbContext.RemoveRange(customer);

                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Customer not found");
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _dbContext.Customers.ToList();
            return customers;
        }

        public Customer GetById(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
            return customer;
        }

        public IEnumerable<Customer> GetCustomersByNameOrCity(string searchStr)
        {
            var customers = _dbContext.Customers.Where(x => x.CustomerName.Contains(searchStr) || x.City.Contains(searchStr)).ToList();
            return customers;
        }

        public Customer Update(Customer entity)
        {
            // var customer = _dbContext.Customers.FirstOrDefault(x => x.CustomerId == entity.CustomerId)
            var customer = GetById(entity.CustomerId);

            if(customer != null)
            {
                customer.CustomerName = entity.CustomerName ?? customer.CustomerName;
                customer.Address = entity.Address ?? customer.Address;
                customer.City =  entity.City ?? customer.City  ;
                customer.PhoneNumber = entity.PhoneNumber ?? customer.PhoneNumber;
                customer.Email = entity.Email ?? customer.Email;

                _dbContext.SaveChanges();
            }
            else {
                throw new Exception("Customer not found");
            }
            

            

            return customer;
        }
    }
}
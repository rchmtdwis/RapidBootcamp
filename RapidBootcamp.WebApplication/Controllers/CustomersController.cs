
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    
    public class CustomersController : Controller
    {
        private readonly ICustomer _customerDal;

        public CustomersController(ICustomer customerDal)
        {
            _customerDal = customerDal;
        }

        public IActionResult Index(string searchStr ="")
        {
            if(TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Customer> customers;

            if(searchStr != ""){
                customers = _customerDal.GetCustomersByNameOrCity(searchStr);
            }
            else{
                customers = _customerDal.GetAll();
            }
            
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _customerDal.GetById(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var newCustomer = _customerDal.Add(customer);
                TempData["Message"] = $"Customer {newCustomer.CustomerName} added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Customer not added"  ;
                return View();
            }
        
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerDal.GetById(id);
            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var updatedCustomer = _customerDal.Update(customer);
                TempData["Message"] = $"Customer edited successfully";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                ViewBag.ErrorMessage = "Customer is not updated";
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerDal.GetById(id);
            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int CustomerId)
        {
            try
            {
                _customerDal.Delete(CustomerId);
                TempData["Message"] = $"Customer with id:{CustomerId} deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Customer not deleted";
                return View();
            }
        }
    }
}
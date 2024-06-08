using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        public IActionResult Index(string searchStr = "")
        {
            // if(TempData["Message"] != null)
            // {
            //     ViewBag.Message = TempData["Message"];
            // }
            // IEnumerable<Customer> products;

            // if(searchStr != ""){
            //     products = _product.GetByCategoryName(searchStr);
            // }
            // else{
            //     products = _product.GetAll();
            // }
            
            var products = _product.GetAll();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = _product.GetById(id)   ;
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                var newProduct = _product.Add(product);
                TempData["Message"] = $"Product {newProduct.ProductName} added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Product not added";
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _product.GetById(id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                var updatedProduct = _product.Update(product);
                TempData["Message"] = $"Product edited successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Product is not updated";
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _product.GetById(id);
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int ProductId)
        {
            try
            {
                _product.Delete(ProductId);
                TempData["Message"] = $"Product with id:{ProductId} deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                ViewBag.ErrorMessage = "Product not deleted";
                return View();
            }
        }
    }
}
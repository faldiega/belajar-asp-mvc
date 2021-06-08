using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer(){ Id=1, Name = "John Smith" },
                new Customer(){ Id=2, Name = "Mary Williams" }
            };

            return customers;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();

            var viewModel = new IndexCustomerMovieVM()
            {
                ListCustomers = customers
            };

            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            try
            {
                var customer = GetCustomers().SingleOrDefault(cus => cus.Id == id);

                var viewModel = new Customer()
                {
                    Id = customer.Id,
                    Name = customer.Name
                };

                return View(viewModel);
            }
            catch (NullReferenceException)
            {
                return HttpNotFound();
            }
        }
    }
}
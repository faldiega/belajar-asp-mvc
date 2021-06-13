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
        protected readonly VIDLYEntities _dbContext;

        public CustomersController()
        {
            this._dbContext = new VIDLYEntities();
        }

        private List<Customers> GetCustomers()
        {
            #region hardcode data
            //var customers = new List<Customer>
            //{
            //    new Customer(){ Id=1, Name = "John Smith" },
            //    new Customer(){ Id=2, Name = "Mary Williams" }
            //};
            #endregion

            var customers = _dbContext.Customers.ToList();

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
                var customer = GetCustomers().SingleOrDefault(cus => cus.ID == id);

                var viewModel = new Customers()
                {
                    ID = customer.ID,
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
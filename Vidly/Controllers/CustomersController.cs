using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Provider;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerProvider provider;

        public CustomersController()
        {
            provider = new CustomerProvider();
        }


        // GET: Customers
        public ActionResult Index()
        {
            #region using hardcode data
            //var customers = GetCustomers();
            //var viewModel = new IndexCustomerMovieVM()
            //{
            //    ListCustomers = customers
            //};
            #endregion

            var viewModel = provider.GetIndexCustomerMembership();
            if (viewModel == null)
                return HttpNotFound();

            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {

            #region using hardcode data
            //var customer = GetCustomers().SingleOrDefault(cus => cus.ID == id);
            //var viewModel = new Customers()
            //{
            //    ID = customer.ID,
            //    Name = customer.Name
            //};
            #endregion

            var customer = provider.GetSingleCustomerMembership(id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}
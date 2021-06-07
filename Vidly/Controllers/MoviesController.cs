using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Fast and Furious" };

            //var customers = new List<Customer>();
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer Ega" },
                new Customer { Name = "Customer Aldi" },
                new Customer { Name = "Customer Bagas" }
            };


            var viewModel = new RandomMovieVM
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }


    }
}
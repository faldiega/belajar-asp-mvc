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
        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie(){ 
                    Id=1, 
                    Name="Shrek!",
                    Description="A cartoon movie that has characters like monster."
                },
                new Movie(){ 
                    Id=2, 
                    Name="Fast and Furious",
                    Description="An action and race car movie. Brian O'conner have to face Dominic Torreto."
                },
                new Movie(){ 
                    Id=3, 
                    Name="Naruto the movie",
                    Description="A ninja movie that want to save the world."
                }
            };

            return movies;
        }

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

        public ActionResult Index()
        {
            var movies = GetMovies();

            var viewModel = new IndexCustomerMovieVM()
            {
                ListMovies = movies
            };

            return View(viewModel);

        }

        public ActionResult Detail(int id)
        {
            try
            {
                var movie = GetMovies().SingleOrDefault(mov => mov.Id == id);

                var viewModel = new Movie()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description
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
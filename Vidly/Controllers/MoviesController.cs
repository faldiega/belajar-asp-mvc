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
        protected readonly VIDLYEntities _dbContext;

        public MoviesController()
        {
            this._dbContext = new VIDLYEntities();
        }

        private List<Movies> GetMovies()
        {
            #region hardcode data
            //var movies = new List<Movie>()
            //{
            //    new Movie(){ 
            //        Id=1, 
            //        Name="Shrek!",
            //        Description="A cartoon movie that has characters like monster."
            //    },
            //    new Movie(){ 
            //        Id=2, 
            //        Name="Fast and Furious",
            //        Description="An action and race car movie. Brian O'conner have to face Dominic Torreto."
            //    },
            //    new Movie(){ 
            //        Id=3, 
            //        Name="Naruto the movie",
            //        Description="A ninja movie that want to save the world."
            //    }
            //};
            #endregion

            var movies = _dbContext.Movies.ToList();

            return movies;
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movies() { Name = "Fast and Furious" };

            //var customers = new List<Customer>();
            var customers = new List<Customers>
            {
                new Customers { Name = "Customer Ega" },
                new Customers { Name = "Customer Aldi" },
                new Customers { Name = "Customer Bagas" }
            };


            var viewModel = new RandomMovieVM
            {
                Movies = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }

        
        // GET: Movies/Index
        public ActionResult Index()
        {
            var movies = GetMovies();

            var viewModel = new IndexCustomerMovieVM()
            {
                ListMovies = movies
            };

            return View(viewModel);

        }

        // GET: Movies/Detail
        public ActionResult Detail(int id)
        {
            try
            {
                var movie = GetMovies().SingleOrDefault(mov => mov.ID == id);

                var viewModel = new Movies()
                {
                    ID = movie.ID,
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
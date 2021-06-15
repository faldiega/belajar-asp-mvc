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
    public class MoviesController : Controller
    {
        private MovieProvider provider;

        public MoviesController()
        {
            provider = new MovieProvider();
        }

        #region Hardcode
        //private List<Movies> GetMovies()
        //{
        //    #region hardcode data
        //    //var movies = new List<Movie>()
        //    //{
        //    //    new Movie(){ 
        //    //        Id=1, 
        //    //        Name="Shrek!",
        //    //        Description="A cartoon movie that has characters like monster."
        //    //    },
        //    //    new Movie(){ 
        //    //        Id=2, 
        //    //        Name="Fast and Furious",
        //    //        Description="An action and race car movie. Brian O'conner have to face Dominic Torreto."
        //    //    },
        //    //    new Movie(){ 
        //    //        Id=3, 
        //    //        Name="Naruto the movie",
        //    //        Description="A ninja movie that want to save the world."
        //    //    }
        //    //};
        //    #endregion

        //    var movies = _dbContext.Movies.ToList();

        //    return movies;
        //}

        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movies() { MovieName = "Fast and Furious" };

        //    //var customers = new List<Customer>();
        //    var customers = new List<Customers>
        //    {
        //        new Customers { CustomerName = "Customer Ega" },
        //        new Customers { CustomerName = "Customer Aldi" },
        //        new Customers { CustomerName = "Customer Bagas" }
        //    };


        //    var viewModel = new RandomMovieVM
        //    {
        //        Movies = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        //// GET: Movies/Index
        //public ActionResult Index()
        //{
        //    var movies = GetMovies();

        //    //var viewModel = new IndexCustomerMovieVM()
        //    //{
        //    //    ListMovies = movies
        //    //};

        //    return View(viewModel);

        //}

        //// GET: Movies/Detail
        //public ActionResult Detail(int id)
        //{
        //    try
        //    {
        //        var movie = GetMovies().SingleOrDefault(mov => mov.MovieID == id);

        //        var viewModel = new Movies()
        //        {
        //            MovieID = movie.MovieID,
        //            MovieName = movie.MovieName,
        //            Description = movie.Description
        //        };

        //        return View(viewModel);
        //    }
        //    catch (NullReferenceException)
        //    {
        //        return HttpNotFound();
        //    }
        //}
        #endregion


        public ActionResult Index()
        {
            var viewModel = provider.GetMovieGenreVM();
            if (viewModel == null)
                return HttpNotFound();

            return View(viewModel);
        }

        public ActionResult Detail(int movieId)
        {
            var movie = provider.GetSingleMovieGenreVM(movieId);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


    }
}
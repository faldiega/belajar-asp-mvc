using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Provider
{
    public class MovieProvider
    {
        protected readonly VIDLYEntities _dbContext;

        public MovieProvider()
        {
            _dbContext = new VIDLYEntities();
        }

        private List<Movies> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }

        private List<Genres> GetGenres()
        {
            return _dbContext.Genres.ToList();
        }

        public List<MovieGenreVM> GetMovieGenreVM()
        {
            var query = from mov in GetMovies()
                        //join gen in GetGenres() on mov.GenreID equals gen.GenreID
                        select new MovieGenreVM
                        {
                            MovieID = mov.MovieID,
                            MovieName = mov.MovieName,
                            Description = mov.Description,
                            Genre = mov.Genres,
                            ReleaseDate = mov.ReleaseDate,
                            DateAdded = mov.DateAdded,
                            NumberInStock = mov.NumberInStock
                        };
            return query.ToList();
        }

        public MovieGenreVM GetSingleMovieGenreVM(int movieId)
        {
            var movie = GetMovieGenreVM().SingleOrDefault(m => m.MovieID == movieId);
            var result = new MovieGenreVM()
            {
                MovieID = movie.MovieID,
                MovieName = movie.MovieName,
                Description = movie.Description,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate,
                DateAdded = movie.DateAdded,
                NumberInStock = movie.NumberInStock
            };

            return result;
        }
    }
}
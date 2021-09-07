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

        public List<Genres> GetGenres()
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
                            GenreID = mov.GenreID,
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

        public Movies GetSingleMovie(int movieId)
        {
            var movie = GetMovies().SingleOrDefault(m => m.MovieID == movieId);
            return movie;
        }

        // CREATE OR UPDATE MOVIE
        public void AddOrUpdateMovie(MovieAddEditVM viewModel)
        {
            var selectedMovie = GetSingleMovie(viewModel.Movie.MovieID);
            if (selectedMovie == null)
            {
                Movies movie = new Movies()
                {
                    MovieName = viewModel.Movie.MovieName,
                    Description = viewModel.Movie.Description,
                    GenreID = viewModel.Movie.GenreID,
                    ReleaseDate = viewModel.Movie.ReleaseDate,
                    DateAdded = viewModel.Movie.DateAdded,
                    NumberInStock = viewModel.Movie.NumberInStock
                };

                _dbContext.Movies.Add(movie);
            }
            else
            {
                selectedMovie.MovieName = viewModel.Movie.MovieName;
                selectedMovie.Description = viewModel.Movie.Description;
                selectedMovie.GenreID = viewModel.Movie.GenreID;
                selectedMovie.ReleaseDate = viewModel.Movie.ReleaseDate;
                selectedMovie.DateAdded = viewModel.Movie.DateAdded;
                selectedMovie.NumberInStock = viewModel.Movie.NumberInStock;
            }

            _dbContext.SaveChanges();
        }

        // DELETE MOVIE
        public void DeleteMovie(int movieId)
        {
            var selectedMovie = GetSingleMovie(movieId);
            if (selectedMovie != null)
            {
                _dbContext.Movies.Remove(selectedMovie);
                _dbContext.SaveChanges();
            }
        }
    }
}
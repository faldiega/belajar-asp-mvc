using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class IndexCustomerMovieVM
    {
        public List<Movie> ListMovies { get; set; }
        public List<Customer> ListCustomers { get; set; }
    }
}
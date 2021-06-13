using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class IndexCustomerMovieVM
    {
        public List<Movies> ListMovies { get; set; }
        public List<Customers> ListCustomers { get; set; }
    }
}
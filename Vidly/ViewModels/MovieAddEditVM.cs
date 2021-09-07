using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieAddEditVM
    {
        public Movies Movie { get; set; }
        public IEnumerable<Genres> Genres { get; set; }
    }
}
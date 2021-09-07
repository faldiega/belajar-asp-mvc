using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieGenreVM
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public int? GenreID { get; set; }
        public Genres Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? NumberInStock { get; set; }
    }
}
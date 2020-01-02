using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class MoviesCountByGenre : Base
    {
        public int GenreId { get; set; }
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }
        [Display(Name = "Movies Count")]
        public int countOfMovies { get; set; }
    }
}
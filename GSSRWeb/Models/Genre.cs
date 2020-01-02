using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Genre
    {
        [Display(Name = "Genre ID")]

        public int GenreId { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "Genre name must be under 100 characters.")]
        [Display(Name = "Genre Name")]

        public string GenreName { get; set; }
    }
}
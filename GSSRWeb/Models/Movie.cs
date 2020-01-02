using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Movie
    {
        [Display(Name = "Movie ID")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Name")]
        [Required]
        [StringLength(100,ErrorMessage = "Movie name must be under 100 characters.")]
        public string MovieName { get; set; }
        [Required]
        [Display(Name = "Year of publish")]
        [Range(1920,2020, ErrorMessage = "Movie year of publish must be between 1920-2020.")]
        public int YearOfPublish { get; set; }
        [Required]
        [Display(Name = "Genre ID")]
        public int GenreId { get; set; }
        [Required]
        [Display(Name = "Movie Duration")]
        [Range(1,300, ErrorMessage = "Movie duration must be between 1-300 minutes.")]
        public int MovieDuration { get; set; }
        public string YoutubeId { get; set; }
        [Required]
        [StringLength(2000, ErrorMessage = "Movie summary must be under 2000 characters.")]
        public string Summary { get; set; }
        [Required]
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Actor> Actor { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Director> Director { get; set; }
        public virtual ICollection<Writer> Writer { get; set; }
    }
}
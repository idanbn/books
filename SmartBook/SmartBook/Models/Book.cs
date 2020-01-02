using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBook.Models
{
    public class Book
    {
        [Display(Name = "Movie ID")]
        public int BookId { get; set; }
        [Display(Name = "Movie Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Movie name must be under 100 characters.")]
        public string BookName { get; set; }
        [Required]
        [Display(Name = "Year of publish")]
        [Range(1920, 2020, ErrorMessage = "Movie year of publish must be between 1920-2020.")]
        public int YearOfPublish { get; set; }

   
        [Required]
        [StringLength(2000, ErrorMessage = "Movie summary must be under 2000 characters.")]
        public string Summary { get; set; }
        [Required]
        public int PictureId { get; set; }
        [Required]
        public int WriterId { get; set; }

        public virtual Picture Picture { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual Writer Writer { get; set; }
       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Website.Models
{
    public class Actor
    {
        [Display(Name = "Actor ID")]
        public int ActorId { get; set; }
        [Display(Name = "Actor Name")]
        [Required]
        [StringLength(100,ErrorMessage ="Name must be under 100 characters.")]
        public string ActorName { get; set; }
        [Display(Name = "Place of birth")]
        [Required]
        [StringLength(50,ErrorMessage = "Place of birth must be under 50 characters. ")]
        public string PlaceOfBirth { get; set; }
        [Display(Name = "Date of birth")]
        [Required]
        [DataType(DataType.Date,ErrorMessage ="Date must be in format - yyyy-mm-dd")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Actor's IMDB page")]
        [Required]
        public string ActorIMDBPage { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
                

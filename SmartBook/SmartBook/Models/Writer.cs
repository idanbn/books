using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBook.Models
{
    public class Writer
    {
        [Display(Name = "Writer ID")]
        public int WriterId { get; set; }
        [Display(Name = "Writer Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Name must be under 100 characters.")]
        public string WriterName { get; set; }
        [Display(Name = "Place of birth")]
        [Required]
        [StringLength(50, ErrorMessage = "Place of birth must be under 50 characters. ")]
        public string PlaceOfBirth { get; set; }
        [Display(Name = "Date of birth")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Date must be in format - yyyy-mm-dd")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBook.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        [Required]
        public string PictureName { get; set; }

    }
}
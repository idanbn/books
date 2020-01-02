using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Models;

namespace GSSRWeb.Models
{
    public class ActorLocation
    {
        public int ActorLocationId { get; set; }
        [Required]
        public int ActorId { get; set; }
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        [Required]
        public double Lat { get; set; }
        [Required]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -90 and 90.")]
        public double Long { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
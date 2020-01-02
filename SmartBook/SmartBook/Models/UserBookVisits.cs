using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Website.Models
{
    public class UserBookVisits
    {
        public int UserMovieVisitsId { get; set; }
        public string UserName { get; set; }
        public int MovieIdVisit { get; set; }
        public DateTime VisitDate { get; set; }
    }
}


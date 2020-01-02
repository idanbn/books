using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class UserActorVisits
    {
        public int UserActorVisitsId { get; set; }
        public string UserName { get; set; }
        public int ActorIdVisit { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
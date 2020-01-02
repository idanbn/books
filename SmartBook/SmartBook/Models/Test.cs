using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartBook.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartBook.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public virtual Test Test { get; set; }
    }
}
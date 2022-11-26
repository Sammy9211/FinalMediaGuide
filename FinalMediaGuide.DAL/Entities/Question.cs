using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalMediaGuide.DAL.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<QuestionAnswer> Answers { get; set; }
        [ForeignKey("QuizType")]
        public int QuizTypeId { get; set; }
        public virtual QuizType QuizType { get; set; }
    }
}

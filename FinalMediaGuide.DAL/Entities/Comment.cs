using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalMediaGuide.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfComment = DateTime.Now;
        public string CommentText { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}

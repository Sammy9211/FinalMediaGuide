using FinalMediaGuide.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.ViewModels
{
    public class CommentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfComment = DateTime.Now;
        public string CommentText { get; set; }
    }
}

using FinalMediaGuide.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.Services.Interfaces
{
    public interface ICommentService
    {
        public List<CommentVM> GetComments();
        public List<CommentVM> GetCommentsByNewsId(int id);
        public CommentVM GetComment(int id);
        public CommentAddEditVM GetCommentForEdit(int id);
        public void Add(CommentAddEditVM model);
        public void Update(CommentAddEditVM model);
        void Delete(int id);    
    }
}

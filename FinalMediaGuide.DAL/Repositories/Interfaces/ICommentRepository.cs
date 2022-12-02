using FinalMediaGuide.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        void Add(Comment model);
        Comment GetForEdit(int id);
        void Update(Comment model);
        Comment GetCommentById(int id);
        List<Comment> GetComments();
        void Delete(int id);

    }
}

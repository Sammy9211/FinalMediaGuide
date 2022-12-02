using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly FinalMediaGuideDataContext _context;
        public CommentRepository(FinalMediaGuideDataContext context)
        {
            _context = context;
        }

        public void Add(Comment model)
        {
            _context.Comments.Add(model);
        }

        public List<Comment> GetComments()
        {
            var data = _context.Comments.Select(c => new Comment
            {
                Id = c.Id,
                CommentText = c.CommentText,
                DateOfComment = c.DateOfComment,
                Email = c.Email,
                Name = c.Name,
                News = c.News,
                NewsId = c.NewsId,
            }).AsNoTracking().ToList();
            return data;
        }

        public Comment GetForEdit(int id)
        {
            var data = _context.Comments.Where(c => c.Id == id)
                .FirstOrDefault();
            return data;
        }

        public Comment GetCommentById(int id)
        {
            var entity = _context.Comments.Where(s => s.Id == id)
            .AsNoTracking()
            .FirstOrDefault();
            return entity;
        }

        public void Update(Comment model)
        {
            var data = _context.Comments.FirstOrDefault(c => c.Id == model.Id);
            data.Name = model.Name;
            data.CommentText = model.CommentText;
            data.Email = model.Email;
            data.DateOfComment = model.DateOfComment;
            data.NewsId = model.NewsId;
        }

        public void Delete(int id)
        {
           var data=_context.Comments.Remove(GetCommentById(id));
        }
    }
}

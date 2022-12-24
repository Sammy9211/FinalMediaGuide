using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using FinalMediaGuide.DAL;
using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _uow;
        public CommentService(ICommentRepository commentRepository, IUnitOfWork uow)
        {
            _commentRepository = commentRepository;
            _uow = uow;
        }

        public void Add(CommentAddEditVM model)
        {
            Comment comment = new Comment()
            {
                CommentText = model.CommentText,
                DateOfComment = model.DateOfComment,
                Email = model.Email,
                Name = model.Name,
                NewsId = model.NewsId,
            };
            _commentRepository.Add(comment);
            _uow.Save();
        }

        public void Delete(int id)
        {
       
            _commentRepository.Delete(id);
            _uow.Save();
        }

        public CommentVM GetComment(int id)
        {
            var comment = _commentRepository.GetCommentById(id);
            CommentVM commentVM = new CommentVM()
            {
                CommentText = comment.CommentText,
                DateOfComment = comment.DateOfComment,
                Email = comment.Email,
                Id = id,
                Name = comment.Name
            };
            return commentVM;
        }

        public CommentAddEditVM GetCommentForEdit(int id)
        {
            var comment = _commentRepository.GetForEdit(id);
            CommentAddEditVM commentAddEditVM = new CommentAddEditVM()
            {
                CommentText = comment.CommentText,
                DateOfComment = comment.DateOfComment,
                Email = comment.Email,
                Id = id,
                Name = comment.Name,
                NewsId = comment.NewsId,
            };
            return commentAddEditVM;
        }

        public List<CommentVM> GetComments()
        {
            var comments = _commentRepository.GetComments().Select(c => new CommentVM()
            {
                CommentText = c.CommentText,
                DateOfComment = c.DateOfComment,
                Email = c.Email,
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            return comments;
        }

        public List<CommentVM> GetCommentsByNewsId(int id)
        {
            var comments = _commentRepository.GetComments().Where(c => c.NewsId == id).Select(c => new CommentVM()
            { 
                Id = c.Id,
                CommentText = c.CommentText,
                DateOfComment = c.DateOfComment,
                Email = c.Email,
                Name = c.Name
            }).ToList();
            return comments;
        }

        public void Update(CommentAddEditVM model)
        {
            var comment = new Comment()
            {
                CommentText = model.CommentText,
                DateOfComment = model.DateOfComment,
                Email = model.Email,
                Id = model.Id,
                Name = model.Name,
                NewsId = model.NewsId
            };
            _commentRepository.Update(comment);
            _uow.Save();
        }
    }
}

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
    public class QuestionAnswerRepository : IQuestionAnswerRepository
    {
        private readonly FinalMediaGuideDataContext _context;
        public QuestionAnswerRepository(FinalMediaGuideDataContext context)
        {
            _context = context;
        }

        public void Add(QuestionAnswer model)
        {
            _context.QuestionAnswers.Add(model);
        }

        public List<QuestionAnswer> GetAllQuestionAnswers()
        {
            var data = _context.QuestionAnswers.Select(qa => new QuestionAnswer { 
                Id = qa.Id,
                IsCorrect = qa.IsCorrect,
                QuestionId = qa.QuestionId,
                Text = qa.Text
            }).AsNoTracking().ToList();
            return data;
        }

        public QuestionAnswer GetForEdit(int id)
        {
            var data = _context.QuestionAnswers.Where(qa => qa.Id == id).Select(s => new QuestionAnswer
            {
                Id = s.Id,
                IsCorrect = s.IsCorrect,
                QuestionId = s.QuestionId,
                Text = s.Text
            }).FirstOrDefault();
            return data;
        }

        public QuestionAnswer GetQuestionAnswerById(int id)
        {
            var entity = _context.QuestionAnswers.Where(s => s.Id == id).Select(s => new QuestionAnswer
            {
                Id = s.Id,
                IsCorrect = s.IsCorrect,
                QuestionId = s.QuestionId,
                Text = s.Text
            }).AsNoTracking()
            .FirstOrDefault();
            return entity;
        }

        public void Update(QuestionAnswer model)
        {
            var entity = _context.QuestionAnswers.FirstOrDefault(s => s.Id == model.Id);
            entity.IsCorrect = model.IsCorrect;
            entity.Text = model.Text;
            entity.QuestionId = model.QuestionId;
        }
    }
}

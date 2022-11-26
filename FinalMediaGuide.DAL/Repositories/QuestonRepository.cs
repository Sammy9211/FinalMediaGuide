using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalMediaGuide.DAL.Repositories
{
    public class QuestonRepository : IQuestionRepository
    {
        private readonly FinalMediaGuideDataContext _context;
        public QuestonRepository(FinalMediaGuideDataContext context)
        {
            _context = context;
        }
        public void Add(Question model)
        {
            _context.Questions.Add(model);
        }

        public List<Question> GetAllQuestions()
        {
            var data = _context.Questions.Select(q => new Question
            {
                Id = q.Id,
                Text=q.Text
            }).AsNoTracking().ToList();
            return data;
        }

        public Question GetForEdit(int id)
        {
            var data = _context.Questions.Where(qt => qt.Id == id).Select(qt => new Question
            {
                Id = qt.Id,
                Text=qt.Text
            }).FirstOrDefault();
            return data;
        }

        public Question GetQuestionById(int id)
        {
            var entity = _context.Questions.Where(qt => qt.Id == id).Select(qt => new Question
            {
                Id = qt.Id,
                Text=qt.Text
            }).AsNoTracking().FirstOrDefault();
            return entity;
        }

        public void Update(Question model)
        {
            var entity = _context.Questions.FirstOrDefault(qt => qt.Id == model.Id);
            entity.Id = model.Id;
            entity.Text = model.Text;
            entity.QuizTypeId = model.QuizTypeId;
        }
    }
}

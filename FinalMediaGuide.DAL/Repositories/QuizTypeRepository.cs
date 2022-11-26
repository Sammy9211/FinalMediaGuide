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
    public class QuizTypeRepository : IQuizTypeRepository
    {
        private readonly FinalMediaGuideDataContext _context;
        public QuizTypeRepository(FinalMediaGuideDataContext context)
        {
            _context = context;
        }

        public void Add(QuizType quizType)
        {
            _context.QuizTypes.Add(quizType);
        }

        public List<QuizType> GetAll()
        {
            var data = _context.QuizTypes.Select(qt => new QuizType{ 
                Id= qt.Id,
                Description= qt.Description,
                Title = qt.Title,
            }).AsNoTracking().ToList();
            return data;
        }

        public QuizType GetById(int id)
        {
            var entity = _context.QuizTypes.Where(qt => qt.Id == id).Select(qt => new QuizType
            {
                Id= qt.Id,
                Description = qt.Description,
                Title = qt.Title,
            }).AsNoTracking().FirstOrDefault();
            return entity;
        }

        public QuizType GetForEdit(int id)
        {
            var data = _context.QuizTypes.Where(qt => qt.Id == id).Select(qt => new QuizType { 
                Id = qt.Id,
                Description = qt.Description,
                Title = qt.Title,
            }).FirstOrDefault();
            return data;
        }

        public void Update(QuizType quizType)
        {
            var entity = _context.QuizTypes.FirstOrDefault(qt => qt.Id == quizType.Id);
            entity.Id = quizType.Id;
            entity.Description = quizType.Description;
            entity.Title = quizType.Title;
        }
    }
}

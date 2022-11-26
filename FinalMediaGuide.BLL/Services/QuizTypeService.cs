using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.Services
{
    public class QuizTypeService : IQuizTypeService
    {
        private readonly IQuizTypeRepository _quizTypeRepository;
        private readonly IUnitOfWork _uow;
        public QuizTypeService(IQuizTypeRepository quizTypeRepository, IUnitOfWork uow)
        {
            _quizTypeRepository = quizTypeRepository;
            _uow = uow;
        }

        public void Add(QuizTypeVM model)
        {
            QuizType quiztype = new QuizType
            {
                Title = model.Title,
                Description = model.Description,
            };
            _quizTypeRepository.Add(quiztype);
            _uow.Save();
        }

        public QuizTypeVM GetQuizTypeById(int id)
        {
            var quiz = _quizTypeRepository.GetById(id);
            QuizTypeVM quizVM = new QuizTypeVM
            {
                Id = id,
                Description = quiz.Description,
                Title = quiz.Title,
            };
            return quizVM;
        }

        public List<QuizTypeVM> GetQuizTypes()
        {
            var quiz = _quizTypeRepository.GetAll().Select(n => new QuizTypeVM
            {
                Id = n.Id,
                Description = n.Description,
                Title = n.Title,
            }).ToList();
            return quiz;
        }

        public void Update(QuizTypeVM model)
        {
            var quiz = new QuizType
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
            };
            _quizTypeRepository.Update(quiz);
            _uow.Save();
        }
    }
}

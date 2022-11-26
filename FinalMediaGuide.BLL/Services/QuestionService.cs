using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories;
using FinalMediaGuide.DAL.Repositories.Interfaces;

namespace FinalMediaGuide.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
        }
    
        public void Add(QuestionAddEditVM model)
        {
            Question question = new Question
            {
                Id= model.Id,
                Text= model.Text,
                QuizTypeId = model.QuizTypeId,
            };
            _questionRepository.Add(question);
            _unitOfWork.Save();
        }

        public QuestionVM GetQuestionById(int id)
        {
            var question = _questionRepository.GetQuestionById(id);
            QuestionVM questionVM= new QuestionVM
            {
               Id = id,
               Text=question.Text,
            };
            return questionVM;
        }

        public List<QuestionVM> GetAllQuestion()
        {
            var question = _questionRepository.GetAllQuestions().Select(n => new QuestionVM
            {
                Id = n.Id,
               Text=n.Text,
            }).ToList();
            return question;
        }

        public void Update(QuestionAddEditVM model)
        {
            var question = new Question
            {
                Id = model.Id,
                Text=model.Text,
                QuizTypeId = model.QuizTypeId
            };
            _questionRepository.Update(question);
            _unitOfWork.Save();
        }
    }
}

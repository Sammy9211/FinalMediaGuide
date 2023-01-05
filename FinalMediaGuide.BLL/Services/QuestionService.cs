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
        private readonly ITranslatorService _translatorService;
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork, ITranslatorService translatorService)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
            _translatorService = translatorService;
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

        public void Update(QuestionAddEditVM model, CultureType cultureType = CultureType.en)
        {
            var entity = _questionRepository.GetQuestionById(model.Id);
            if (cultureType == CultureType.en)
            {
                entity.Text = model.Text;
                entity.QuizTypeId = model.QuizTypeId;
                _questionRepository.Update(entity);
            }
            else 
            {
                var tablename = "Questions";
                _translatorService.Fill(model,cultureType,tablename,model.Id);
            }
            _unitOfWork.Save();
            //var question = new Question
            //{
            //    Id = model.Id,
            //    Text=model.Text,
            //    QuizTypeId = model.QuizTypeId
            //};
            //_questionRepository.Update(question);
            //_unitOfWork.Save();
        }

        public QuestionAddEditVM GetQuestionForEdit(int id)
        {
            var question = _questionRepository.GetForEdit(id);
            QuestionAddEditVM model = new QuestionAddEditVM { 
                Id= id,
                QuizTypeId= question.QuizTypeId,
                Text =question.Text,
            };
            return model;
        }
    }
}

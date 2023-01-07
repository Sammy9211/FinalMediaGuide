using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Controllers
{
    public class QuestionAnswerController : Controller
    {
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        public QuestionAnswerController(IQuestionAnswerRepository questionAnswerRepository)
        {
            _questionAnswerRepository = questionAnswerRepository;
        }

        public IActionResult Index()
        {
            var data = _questionAnswerRepository.GetQuestionAnswers();
            return View(data);
        }
    }
}

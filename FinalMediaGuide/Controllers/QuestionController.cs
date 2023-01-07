using FinalMediaGuide.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            var data = _questionService.GetAllQuestion();
            return View(data);
        }
    }
}

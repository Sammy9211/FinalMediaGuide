using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IQuizTypeService _quizTypeService;
        public QuestionController(IQuestionService questionService,IQuizTypeService quizTypeService)
        {
            _questionService = questionService;
            _quizTypeService = quizTypeService;
        }

        public IActionResult Index()
        {
            var data = _questionService.GetAllQuestion();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddEdit(int? id) { 
            QuestionAddEditVM model = id.HasValue ? _questionService.GetQuestionForEdit(id.Value) : new QuestionAddEditVM() {Id = 0};
            ViewBag.QuestionTypes = _quizTypeService.GetQuizTypes();
            return PartialView("_AddEdit",model);
        }
        [HttpPost]
        public IActionResult AddEdit(QuestionAddEditVM model) {
            if (model.Id == 0)
            {
                _questionService.Add(model);
            }
            else {
                _questionService.Update(model);
            }
            return RedirectToAction("Index");
        }
    }
}

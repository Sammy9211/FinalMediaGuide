using FinalMediaGuide.BLL.Services;
using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionAnswerController : Controller
    {
        private readonly IQuestionAnswerService _questionAnswerService;
        public QuestionAnswerController(IQuestionAnswerService questionAnswerService)
        {
            _questionAnswerService = questionAnswerService;
        }
        public IActionResult Index()
        {
            var data = _questionAnswerService.GetQuestionAnswers();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddEdit(int? id, int? questionId) {
            QuestionAnswerAddEditVM model = id.HasValue ? _questionAnswerService.GetForEdit(id.Value) : new QuestionAnswerAddEditVM() { Id = 0,QuestionId = questionId.Value};
            return PartialView("_AddEdit",model);
        }
        [HttpPost]
        public IActionResult AddEdit(QuestionAnswerAddEditVM model) {
            if(model.Id == 0)
            {
                _questionAnswerService.Add(model);
            }
            else
            {
                _questionAnswerService.Update(model);
            }
            return RedirectToAction("Index");
        }
    }
}

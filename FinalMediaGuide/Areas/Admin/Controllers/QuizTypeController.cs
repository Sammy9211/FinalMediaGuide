using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class QuizTypeController : Controller
    {
        private readonly IQuizTypeService _quizTypeService;
        public QuizTypeController(IQuizTypeService quizTypeService)
        {
            _quizTypeService = quizTypeService;
        }

        public IActionResult Index()
        {
            var data = _quizTypeService.GetQuizTypes();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddEdit(int? id) {
            QuizTypeVM model = id.HasValue ? _quizTypeService.GetQuizTypeById(id.Value) : new QuizTypeVM() { Id = 0};
            return PartialView("_AddEdit",model);
        }
        [HttpPost]
        public IActionResult AddEdit(QuizTypeVM model) {
            if (model.Id == 0)
            {
                _quizTypeService.Add(model);
            }
            else {
                _quizTypeService.Update(model);
            }
            return RedirectToAction("Index");
        }
    }
}

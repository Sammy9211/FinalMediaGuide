using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            var data = _newsService.GetAllNews();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddEdit(int? newsId) {
            NewsVM model = newsId.HasValue ? _newsService.GetNewsById(newsId.Value) : new NewsVM() { Id = 0};
            return PartialView("_AddEdit",model);
        }
        [HttpPost]
        public IActionResult AddEdit(NewsVM model)
        {
            if (model.Id == 0)
            {
                _newsService.Add(model);
            }
            else { 
                _newsService.Update(model);
            }
            return RedirectToAction("Index");
        }
    }
}

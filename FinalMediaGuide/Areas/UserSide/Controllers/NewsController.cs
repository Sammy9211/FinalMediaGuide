using FinalMediaGuide.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.UserSide.Controllers
{
    [Area("UserSide")]
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
        public IActionResult NewsSingle(int id) {
            var entity = _newsService.GetNewsById(id);
            return View(entity);
        }
    }
}

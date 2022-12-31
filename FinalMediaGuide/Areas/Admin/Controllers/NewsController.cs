using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsController(INewsService newsService, IWebHostEnvironment webHostEnvironment)
        {
            _newsService = newsService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = _newsService.GetAllNews();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddEdit(int? newsId)
        {
            NewsVM model = newsId.HasValue ? _newsService.GetNewsById(newsId.Value) : new NewsVM() { Id = 0 };
            return PartialView("_AddEdit", model);
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(NewsVM model, IFormFile fileName)
        {
            if (fileName != null)
            {
                string path = "/Files/" + fileName.FileName;
                using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create)) { await fileName.CopyToAsync(fileStream); }
                model.ImageFile = path;
                if (model.Id == 0)
                {
                    _newsService.Add(model);
                }
                else
                {
                    _newsService.Update(model);
                }
            }
            return RedirectToAction("Index");
        }
    }
}

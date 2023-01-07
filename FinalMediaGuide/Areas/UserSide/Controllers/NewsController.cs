using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using FinalMediaGuide.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.UserSide.Controllers
{
    [Area("UserSide")]
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;
        private readonly ICommentService _commentService;
        public NewsController(INewsService newsService,ICommentService commentService)
        {
            _newsService = newsService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var data = _newsService.GetAllNews(CurrentCulture);
            return View(data);
        }
        public IActionResult NewsSingle(int id) {
            var entity = _newsService.GetNewsById(id,CurrentCulture);
            ViewBag.Comments = _commentService.GetCommentsByNewsId(id);
            return View(entity);
        }
        public IActionResult AddComment(int newsId) {
            return PartialView("_AddComment");
        }
        [HttpPost]
        public IActionResult AddComment(CommentAddEditVM model) {
            _commentService.Add(model);
            return RedirectToAction("Index");
        }
    }
}

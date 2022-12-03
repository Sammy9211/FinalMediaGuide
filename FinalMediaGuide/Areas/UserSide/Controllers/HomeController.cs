using Microsoft.AspNetCore.Mvc;

namespace FinalMediaGuide.Areas.UserSide.Controllers
{
    [Area("UserSide")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Book()
        {
            return PartialView();
        }
    }
}

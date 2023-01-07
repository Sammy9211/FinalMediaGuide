using Microsoft.AspNetCore.Localization;
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
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Book()
        {
            return PartialView();
        }
    }
}

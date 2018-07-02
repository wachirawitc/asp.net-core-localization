using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;

            return View();
        }

        public IActionResult SetThai()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("th-TH"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("Web.Language", cookieValue, option);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SetEnglish()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-GB"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("Web.Language", cookieValue, option);
            return RedirectToAction(nameof(Index));
        }
    }
}
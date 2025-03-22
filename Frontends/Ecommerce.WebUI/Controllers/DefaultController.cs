using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Directory1 = "Ana Sayfa";
            ViewBag.Directory2 = "Urun Listesi";
            var user = User.Claims; // Bilgi gormek icin
            int x;
            return View();
        }
    }
}

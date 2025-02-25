using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            //Bu id Kategori icinden geliyor
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id )
        {
            ViewBag.x = id;
            return View();
        }
    }
}

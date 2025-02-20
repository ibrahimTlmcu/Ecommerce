using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

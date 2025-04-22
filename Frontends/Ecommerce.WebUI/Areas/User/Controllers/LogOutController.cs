using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

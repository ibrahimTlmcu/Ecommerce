using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

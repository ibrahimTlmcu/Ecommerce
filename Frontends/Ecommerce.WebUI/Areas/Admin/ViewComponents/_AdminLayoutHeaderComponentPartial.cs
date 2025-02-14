using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

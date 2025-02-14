using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

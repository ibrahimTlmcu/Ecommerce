using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutMainSectionViewbagComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

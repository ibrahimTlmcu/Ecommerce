using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.ViewComponents.UserLayoutViewComponent
{
    public class _UserLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

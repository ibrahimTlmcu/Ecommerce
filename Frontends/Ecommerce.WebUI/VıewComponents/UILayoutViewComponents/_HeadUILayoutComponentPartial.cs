using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

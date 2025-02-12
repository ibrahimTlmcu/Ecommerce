using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

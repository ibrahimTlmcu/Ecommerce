using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

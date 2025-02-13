using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.ProductListViewComponent
{
    public class _ProductListGetProductCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

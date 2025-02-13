using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

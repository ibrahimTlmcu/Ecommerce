using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartViewComponentsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

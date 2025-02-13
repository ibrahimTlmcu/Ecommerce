using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

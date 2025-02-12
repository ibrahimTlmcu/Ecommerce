using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

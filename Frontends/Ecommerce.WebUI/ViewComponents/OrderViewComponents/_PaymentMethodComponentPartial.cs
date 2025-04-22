using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}

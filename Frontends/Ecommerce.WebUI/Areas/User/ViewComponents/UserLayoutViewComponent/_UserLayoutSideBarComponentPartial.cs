using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.ViewComponents.UserLayoutViewComponent
{
    public class _UserLayoutSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }   
    
}

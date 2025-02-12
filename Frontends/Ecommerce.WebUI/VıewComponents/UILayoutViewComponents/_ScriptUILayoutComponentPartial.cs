using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

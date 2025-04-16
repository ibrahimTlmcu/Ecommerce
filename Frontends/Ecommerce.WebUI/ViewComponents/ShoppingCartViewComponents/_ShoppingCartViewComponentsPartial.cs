using Ecommerce.WebUI.Services;
using Ecommerce.WebUI.Services.CatalogServices.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.VıewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartViewComponentsPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public _ShoppingCartViewComponentsPartial(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
           var basketTotal = await _basketService.GetBasket();
           var basketItems = basketTotal.BasketItems;
           return View(basketItems);
        }
    }
}

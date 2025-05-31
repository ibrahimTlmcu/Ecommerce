using Ecommerce.WebUI.Services;
using Ecommerce.WebUI.Services.CatalogServices.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public _OrderSummaryComponentPartial(IBasketService basketService, ILoginService loginService)
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

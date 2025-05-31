using Ecommerce.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Ecommerce.WebUI.Services.CatalogServices.OfferDiscountService;
using Ecommerce.WebUI.ViewComponents.DefaultViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {

        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GettAllOfferDiscountAsync();
            return View(values);
        }
    }
}

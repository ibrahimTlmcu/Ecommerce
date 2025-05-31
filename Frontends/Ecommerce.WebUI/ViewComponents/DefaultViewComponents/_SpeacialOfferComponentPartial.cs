using Ecommerce.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _SpeacialOfferComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferServices _specialOfferServices;

        public _SpeacialOfferComponentPartial(ISpecialOfferServices specialOfferServices)
        {
            _specialOfferServices = specialOfferServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferServices.GettAllSpecialOfferAsync();
            return View(values);
          
        }
    }
}

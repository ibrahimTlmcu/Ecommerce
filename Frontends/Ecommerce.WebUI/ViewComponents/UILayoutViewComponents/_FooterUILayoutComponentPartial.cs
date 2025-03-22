using Ecommerce.Catalog.Dtos.AboutDto;
using Ecommerce.DtoLayer.CatalogDtos.AboutDtos;
using Ecommerce.WebUI.Services.CatalogServices.AboutService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ResultAboutDto = Ecommerce.DtoLayer.CatalogDtos.AboutDtos.ResultAboutDto;

namespace Ecommerce.WebUI.VıewComponents.UILayoutViewComponents
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class _FooterUILayoutComponentPartial : ViewComponent
    {


        private readonly IAboutService _aboutService;

        public _FooterUILayoutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _aboutService.GettAllAboutAsync();
            return View(values);
        }

    }

}

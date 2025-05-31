using Ecommerce.DtoLayer.CatalogDtos.FeatureDtos;
using Ecommerce.WebUI.Services.CatalogServices.FeautureService;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}

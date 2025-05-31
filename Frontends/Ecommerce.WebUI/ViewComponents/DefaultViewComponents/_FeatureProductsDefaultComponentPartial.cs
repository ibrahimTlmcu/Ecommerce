
using Ecommerce.DtoLayer.CatalogDtos.CategoryDtos;
using Ecommerce.DtoLayer.CatalogDtos.ProductDtos;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Ecommerce.WebUI.ViewComponents.DefaultViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial :ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        [Route("Index")]

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GettAllProductAsync();
            return View(values);
        }
    }

}


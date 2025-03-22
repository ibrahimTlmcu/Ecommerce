
using Ecommerce.DtoLayer.CatalogDtos.ProductDtos;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {

        //Urun detaylari bu alanda gelecek Urune tiklandigi zaman bu alana gidilecek ve urun detaylari burada cagirilacak
        private readonly IHttpClientFactory _httpClientFactory;
        
        private readonly IProductService _productService;

        public _ProductDetailFeatureComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetByIdProduct(id);
            return View(values);

        }



    }
}

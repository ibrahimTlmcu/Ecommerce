
using Ecommerce.DtoLayer.CatalogDtos.ProductDetailDtos;
using Ecommerce.WebUI.Services.CatalogServices.ProductDetailServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IProductDetailService _productDetailService;

        public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
            #region diger yontem
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7078/api/ProductDetails/GetProductDetailByProductId?id=" + id);

            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            //    return View(values);
            //}
            //return View();
            #endregion
        }
    }
}

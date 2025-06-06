﻿ using Ecommerce.DtoLayer.CatalogDtos.ProductImage;
using Ecommerce.WebUI.Services.CatalogServices.ProductImageService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(values);
            //if (string.IsNullOrEmpty(id))
            //{
            //    return View("ID boş geldi.");
            //}

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7078/api/ProductImages/ProductImagesByProductId?id={id}");

            //if (!responseMessage.IsSuccessStatusCode)
            //{
            //    var errorMessage = await responseMessage.Content.ReadAsStringAsync();
            //    return View("API başarısız: {responseMessage.StatusCode}, Hata: {errorMessage}");
            //}

            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //if (string.IsNullOrEmpty(jsonData))
            //{
            //    return View("API'den boş yanıt alındı.");
            //}

            //var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
            //if (values == null)
            //{
            //    return View("API'den dönen veri hatalı.");
            //}

            //return View(values ?? new GetByIdProductImageDto());
        }
    }
}

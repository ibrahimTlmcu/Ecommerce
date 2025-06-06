﻿using Ecommerce.DtoLayer.CatalogDtos.ProductDtos;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Ecommerce.WebUI.ViewComponents.DefaultViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<_CarouselDefaultComponentPartial> _logger;

        private readonly IProductService _productService;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory, ILogger<_CarouselDefaultComponentPartial> logger, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id )
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);

            #region  diger yontem
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7078/api/Product/ProductListWithCategoryByCategoryId?id=" + id);
            //Console.WriteLine("Metot çalıştı!");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    Console.WriteLine("Gelen JSON: " + jsonData);
            //    System.Diagnostics.Debug.WriteLine("Gelen JSON: " + jsonData);

            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            //if (!responseMessage.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("API Hatası! Kod: " + responseMessage.StatusCode);
            //    _logger.LogError("API Hatası! Kod: {StatusCode}", responseMessage.StatusCode);
            //}
            #endregion

        }
    }
}

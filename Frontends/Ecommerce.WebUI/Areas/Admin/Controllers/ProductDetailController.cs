using Ecommerce.DtoLayer.CatalogDtos.CategoryDtos;
using Ecommerce.DtoLayer.CatalogDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
       

        private readonly IHttpClientFactory _httpClientFactory;
        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]

        [Route("ProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductDetail(string id)
        {
            ViewBag.v0 = "Ana Sayfa";
            ViewBag.v1 = "Urunler";
            ViewBag.v2 = "Urun Aciklama ve Guncelleme";
            ViewBag.v3 = "Urun Islemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/ProductDetails/GetProductDetailByProductId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("ProductDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7078/api/ProductDetails/", stringContent);
                                                        
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

            }
            return View();
        }

    }
}

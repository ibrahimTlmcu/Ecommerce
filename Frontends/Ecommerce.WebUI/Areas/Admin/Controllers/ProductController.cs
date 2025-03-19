using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ecommerce.DtoLayer.CatalogDtos.CategoryDtos;
using Ecommerce.DtoLayer.CatalogDtos.ProductDtos;
using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;
using Ecommerce.Catalog.Dtos.CategoryDtos;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
       
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        void ProductViewBagList()
        {

            ViewBag.v0 = "Ana Sayfa";
            ViewBag.v1 = "Urunler";
            ViewBag.v2 = "Urun Listesi";
            ViewBag.v3 = "Urun Islemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList();
            var values = await _productService.GettAllProductAsync();
            return View(values); 
        }
       

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7078/api/Categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var categoryValues =  await _productService.GettAllProductAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryValues);

            //List<SelectListItem> categoryValues = (from x in values
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.CategoryName,
            //                                           Value = x.CategoryId
            //                                       }).ToList();
            //ViewBag.CategoryValues = categoryValues;

            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
            
        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }




        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            //var client1 = _httpClientFactory.CreateClient();
            //var responseMessage1 = await client1.GetAsync("https://localhost:7078/api/Categories");
            //var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            //var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);

            //List<SelectListItem> categoryValues1 = (from x in values1
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.CategoryName,
            //                                           Value = x.CategoryId.ToString()
            //                                       }).ToList();
            //ViewBag.CategoryValues = categoryValues1;

            
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7078/api/Products/" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            //    return View(values);
            //}
            
            return View();
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
            
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7078/api/Product/ProductListWithCategory/");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            ////Serialeze Metinde => Jsona donusum yapiyor Ekle Guncelle daha cok 
            ////Deserialeize Jsondan => Metine  Listele idye gore getir daha cok 
            return View();
        }
    }
}

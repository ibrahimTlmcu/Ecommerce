using Ecommerce.Catalog.Dtos.ProductDto;
using Ecommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductList()
        {
            var values = await _ProductService.GettAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(string id)
        {
            var values = _ProductService.GetByIdProduct(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  Product ct = new Product(); 

        //  ct.ProductName = createProduct.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _ProductService.CreateProductAsync(createProductDto);
            return Ok("Urun islemi basariyla eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _ProductService.DeleteProductAsync(id);
            return Ok("Urun  basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _ProductService.UpdateProductAsync(updateProductDto);
            return Ok("Urun basariyla guncellendi");
        }


        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _ProductService.GetProductsWithCategoryAsync();
            return Ok(values);  
        }

        [HttpGet("ProductListWithCategoryByCategoryId")]
        public async Task<IActionResult> ProductListWithCategoryByCategoryId(string id)
        {
            var values = await _ProductService.GetProductsWithCategoryByCategoryIdAsync(id);
            return Ok(values);
        }
    }
}

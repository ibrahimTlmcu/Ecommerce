using Ecommerce.Catalog.Dtos.ProductDetailDtos;
using Ecommerce.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailsService;

        public ProductDetailsController(IProductDetailService ProductDetailsService)
        {
            _ProductDetailsService = ProductDetailsService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _ProductDetailsService.GettAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductDetailsById(string id)
        {
            var values = await _ProductDetailsService.GetByIdProductDetail(id);
            return Ok(values);
        }
        [HttpGet("GetProductDetailByProductId/{id}")]

        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var values = await _ProductDetailsService.GetByProductIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  ProductDetails ct = new ProductDetails(); 

        //  ct.ProductDetailsName = createProductDetails.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailsDto)
        {
            await _ProductDetailsService.CreateProductDetailAsync(createProductDetailsDto);
            return Ok("Urun islemi basariyla eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProductDetails(string id)
        {
            await _ProductDetailsService.DeleteProductDetailAsync(id);
            return Ok("Urun  basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetailsDto)
        {
            await _ProductDetailsService.UpdateProductDetailAsync(updateProductDetailsDto);
            return Ok("Urun basariyla guncellendi");
        }
    }
}

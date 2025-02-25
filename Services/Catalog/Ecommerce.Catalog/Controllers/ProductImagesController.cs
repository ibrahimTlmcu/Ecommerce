using Ecommerce.Catalog.Dtos.ProductImageDto;
using Ecommerce.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductImageList()
        {
            var values = await _ProductImageService.GettAllProductImageAsync();
            return Ok(values);
        }


        [HttpGet("ProductImagesByProductId")]

        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var values = await _ProductImageService.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }



        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values =await  _ProductImageService.GetByIdProductImage(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  ProductImage ct = new ProductImage(); 

        //  ct.ProductImageName = createProductImage.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _ProductImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Urun Gorsel ekleme islemi basarili.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Gorsel basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Gorsel basariyla guncellendi");
        }

    }
}

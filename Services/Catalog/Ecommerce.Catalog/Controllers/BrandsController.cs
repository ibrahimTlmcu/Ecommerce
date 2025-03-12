using Ecommerce.Catalog.Dtos.BrandDtos;
using Ecommerce.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        [HttpGet]

        public async Task<IActionResult> BrandList()
        {
            var values = await _BrandService.GettAllBrandAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBrandById(string id)
        {
            var values = await _BrandService.GetByIdBrand(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  Brand ct = new Brand(); 

        //  ct.BrandName = createBrand.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _BrandService.CreateBrandAsync(createBrandDto);
            return Ok("Marka islemi basariyla eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _BrandService.DeleteBrandAsync(id);
            return Ok("Marka basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _BrandService.UpdateBrandAsync(updateBrandDto);
            return Ok("Kategori basariyla guncellendi");
        }
    }
}

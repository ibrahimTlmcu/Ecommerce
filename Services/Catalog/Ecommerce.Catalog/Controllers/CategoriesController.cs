using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GettAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await _categoryService.GetByIdCategory(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  Category ct = new Category(); 

        //  ct.CategoryName = createCategory.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult>CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori islemi basariyla eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await  _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori basariyla guncellendi");
        }

    }
}

using Ecommerce.Catalog.Dtos.AboutDto;
using Ecommerce.Catalog.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _AboutService;

        public AboutsController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        [HttpGet]

        public async Task<IActionResult> AboutList()
        {
            var values = await _AboutService.GettAllAboutAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAboutById(string id)
        {
            var values = await _AboutService.GetByIdAbout(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  About ct = new About(); 

        //  ct.AboutName = createAbout.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _AboutService.CreateAboutAsync(createAboutDto);
            return Ok("Hakkimda islemi basariyla eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _AboutService.DeleteAboutAsync(id);
            return Ok("Hakkimda  basariyla silindi");
        }

        [HttpPut] // 🔄 Veya [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutDto updateAboutDto)
        {
            await _AboutService.UpdateAboutAsync(updateAboutDto);
            return Ok();
        }


    }
}


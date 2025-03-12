using Ecommerce.Catalog.Dtos.SpecialOfferDtos;
using Ecommerce.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {

        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOfferController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }

        [HttpGet]

        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _SpecialOfferService.GettAllSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _SpecialOfferService.GetByIdSpecialOffer(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  SpecialOffer ct = new SpecialOffer(); 

        //  ct.SpecialOfferName = createSpecialOffer.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Ozel Teklif islemi basariyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer([FromQuery] string id)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Ozel Teklif  basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Ozel Teklif  basariyla guncellendi");
        }

    }
}


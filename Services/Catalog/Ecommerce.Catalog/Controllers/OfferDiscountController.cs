
using Ecommerce.Catalog.Dtos.OfferDiscountDtos;
using Ecommerce.Catalog.Services.OfferDiscountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountController : ControllerBase
    {
        private readonly IOfferDiscountService _OfferDiscountService;

        public OfferDiscountController(IOfferDiscountService OfferDiscountService)
        {
            _OfferDiscountService = OfferDiscountService;
        }

        [HttpGet]

        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await _OfferDiscountService.GettAllOfferDiscountAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            var values = await _OfferDiscountService.GetByIdOfferDiscount(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  OfferDiscount ct = new OfferDiscount(); 

        //  ct.OfferDiscountName = createOfferDiscount.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Ozel Teklif islemi basariyla eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _OfferDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("Ozel Teklif basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _OfferDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Ozel Teklif basariyla guncellendi");
        }

    }

}

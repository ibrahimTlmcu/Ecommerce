using Ecommerce.Discount.Dtos;
using Ecommerce.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]

        public async Task<IActionResult> CouponList()
        {
            var values = await _discountService.GettAllCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdCoupon(int id)
        {
            var values = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(values);  
        }

        [HttpGet("GetCodeDetailByCodeAsync")]

        public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        {
            var values = await _discountService.GetCodeDetailByCodeAsync(code);
            return Ok(values);
        }



        [HttpPost]

        public async Task<IActionResult> CreateCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponDto(createCouponDto);
            return Ok("Kupon basariyla olusturuldu"); 
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponDto(updateCouponDto);
            return Ok("Indirim kuponu basariyla guncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Silindi");
        }

        [HttpGet("GetDiscountCouponCountRateAsync")]

        public IActionResult GetDiscountCouponCountRateAsync(string code)
        {
            var values =  _discountService.GetDiscountCouponCountRateAsync(code);
            
            return Ok(values);
        }
    }
}

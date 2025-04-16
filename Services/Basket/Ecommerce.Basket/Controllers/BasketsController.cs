using Ecommerce.Basket.Dtos;
using Ecommerce.Basket.LoginServices;
using Ecommerce.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
            {
            #region DENME


            ////var values = await _basketService.GetBasket(_loginService.GetUserId);
            //var isAuthenticated = HttpContext.User.Identity?.IsAuthenticated;
            //Console.WriteLine($"Authenticated: {isAuthenticated}");

            //// Authorization header'dan token'ı al
            //var token = HttpContext.Request.Headers["Authorization"].ToString();
            //Console.WriteLine($"Token: {token}");

            //// JWT içerisinden farklı claim'lere erişim
            //var userId = HttpContext.User?.FindFirst("sub")?.Value; // "sub" genellikle kullanıcı kimliğini tutar.
            //var userEmail = HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value;
            //var userName = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;

            //// Eğer "sub" claim'i null ise alternatif olarak email veya diğer bilgileri kullanabiliriz
            //if (string.IsNullOrEmpty(userId))
            //{
            //    if (!string.IsNullOrEmpty(userEmail))
            //    {
            //        // Eğer email varsa, onu kullanıcı ID'si olarak kullanabilirsiniz
            //        userId = userEmail; // Kullanıcıyı email üzerinden tanımlayabilirsiniz
            //        Console.WriteLine($"User ID from Email: {userId}");
            //    }
            //    else if (!string.IsNullOrEmpty(userName))
            //    {
            //        // Eğer name varsa, onu kullanıcı ID'si olarak kullanabilirsiniz
            //        userId = userName; // Kullanıcıyı name üzerinden tanımlayabilirsiniz
            //        Console.WriteLine($"User ID from Name: {userId}");
            //    }
            //    else
            //    {
            //        return Unauthorized("Kullanıcı kimliği alınamadı.");
            //    }
            //}

            //// User ID'yi kullanarak işlemlere devam et
            //var values1 = await _basketService.GetBasketAsync(_loginService.GetUserId);
            //var values2 = await _basketService.GetBasketAsync(userId);
            //return Ok(values2);
            #endregion
            var values = await _basketService.GetBasketAsync(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket([FromBody] BasketTotalDto basketTotalDto)
        {
            // 1. Gelen DTO'nun null olup olmadığını kontrol et
            if (basketTotalDto == null)
            {
                return BadRequest("Sepet verileri boş olamaz.");
            }

            // 2. Kullanıcı ID'sini ekle
            basketTotalDto.UserId = _loginService.GetUserId;

            // 3. BasketItems null ise boş liste ata (TotalPrice hatası önlemi)
            basketTotalDto.BasketItems = basketTotalDto.BasketItems ?? new List<BasketItemDto>();

            // 4. Servise gönder
            await _basketService.SaveBasketAsync(basketTotalDto);

            return Ok(new
            {
                Message = "Sepet başarıyla kaydedildi",
                TotalPrice = basketTotalDto.TotalPrice,
                ItemCount = basketTotalDto.BasketItems.Count
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            // Sepeti silme işlemi
            await _basketService.DeleteBasketAsync(_loginService.GetUserId);
            return Ok("Sepet başarıyla silindi");
        }
    }
}

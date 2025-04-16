using Ecommerce.Basket.Dtos;
using Ecommerce.Basket.Services;
using Ecommerce.Basket.Settings;
using Newtonsoft.Json;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;

    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }

    // Sepeti silme işlemi
    public async Task DeleteBasketAsync(string userId)
    {
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }

    // Sepeti alma işlemi
    public async Task<BasketTotalDto> GetBasketAsync(string userId)
    {
        try
        {
            // Redis'ten sepet verisini al
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            // Sepet verisi varsa, deserialize et ve döndür
            if (!existBasket.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<BasketTotalDto>(existBasket);
            }


            // Eğer veri yoksa null döndür
            return null;
        }
        catch (Exception)
        {
            throw; // Hata varsa dışarı fırlat
        }
    }

    // Sepeti kaydetme işlemi
    public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
    {
        // Sepet verisini serialize edip Redis'e kaydet
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonConvert.SerializeObject(basketTotalDto));
    }
}
using Ecommerce.DtoLayer.DiscountDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.DiscountService
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
       Task<int> GetDiscountCouponCountRateAsync(string code);
    }
}

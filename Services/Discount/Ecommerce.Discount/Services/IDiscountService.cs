using Ecommerce.Discount.Dtos;

namespace Ecommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GettAllCouponAsync();

        Task CreateDiscountCouponDto(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponDto(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);

        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
    }
}

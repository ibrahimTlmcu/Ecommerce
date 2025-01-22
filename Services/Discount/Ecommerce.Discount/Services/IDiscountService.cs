using Ecommerce.Discount.Dtos;

namespace Ecommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GettAllCouponAsync();

        Task CreateCouponDto(CreateCouponDto createCouponDto);
        Task UpdateCouponDto(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);

        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    }
}

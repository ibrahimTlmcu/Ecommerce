using Dapper;
using Ecommerce.Discount.Context;
using Ecommerce.Discount.Dtos;

namespace Ecommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponDto(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) " +
                "values (@code,@rate, @isActive ,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var coneection = _context.CreateConnection())
            {
                await coneection.ExecuteAsync(query, parameters);
            }

        }

        public Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();

        }

        public Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCouponDto>> GettAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCouponDto(UpdateCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }
    }
}

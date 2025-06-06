﻿using Dapper;
using Ecommerce.Discount.Context;
using Ecommerce.Discount.Dtos;
using System.Reflection.Metadata;

namespace Ecommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponDto(CreateDiscountCouponDto createCouponDto)
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

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, paramaters);
                return values;

            }
        }  

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code )
        {
            string query = "Select * From Coupons Where code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
                return values;

            }
        }

        public int GetDiscountCouponCountRateAsync(string code)
        {
            string query = "Select Rate From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query,parameters);
                return values;
                //API TARAFINDA INIDIRIM MIKTARINI YAAKALDIK
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GettAllCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateDiscountCouponDto(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set " +
                "Code =@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate " +
                "where CouponId=@couponId";

            var parameters = new DynamicParameters();
            
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}

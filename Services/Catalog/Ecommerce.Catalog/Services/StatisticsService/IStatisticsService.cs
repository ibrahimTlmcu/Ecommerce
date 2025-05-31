namespace Ecommerce.Catalog.Services.StatisticsService
{
    public interface IStatisticsService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}

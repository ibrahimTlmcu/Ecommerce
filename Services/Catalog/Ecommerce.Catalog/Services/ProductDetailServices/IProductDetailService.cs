using Ecommerce.Catalog.Dtos.ProductDetailDtos;


namespace Ecommerce.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService 
    {
        Task<List<ResultProductDetailDto>> GettAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetail(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
        


    }
}

using Ecommerce.DtoLayer.CatalogDtos.FeatureDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.FeautureService
{
    public interface IFeatureService
    {

        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
    }
}

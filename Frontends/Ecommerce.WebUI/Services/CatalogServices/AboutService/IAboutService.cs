using Ecommerce.DtoLayer.CatalogDtos.AboutDtos;


namespace Ecommerce.WebUI.Services.CatalogServices.AboutService
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GettAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}

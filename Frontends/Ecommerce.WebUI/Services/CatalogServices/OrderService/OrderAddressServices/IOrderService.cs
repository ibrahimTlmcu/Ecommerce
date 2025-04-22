using Ecommerce.DtoLayer.OrderDtos.OrderAddressDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.OrderService.OrderAddressServices
{
    public interface IOrderService
    {
        //Task<List<ResultAboutDto>> GettAllAboutAsync();
        Task CreateOrderAddress(CreateOrderAddressDto createAboutDto);
       // Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
       // Task DeleteAboutAsync(string id);
       // Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}

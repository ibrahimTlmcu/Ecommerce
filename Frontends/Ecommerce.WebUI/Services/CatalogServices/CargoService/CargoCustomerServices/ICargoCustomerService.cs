using Ecommerce.DtoLayer.CargoDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.CargoService.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
       
    }
}

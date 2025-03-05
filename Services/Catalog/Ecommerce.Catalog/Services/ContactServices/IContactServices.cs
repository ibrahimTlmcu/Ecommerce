using Ecommerce.Catalog.Dtos.ContactDtos;

namespace Ecommerce.Catalog.Services.ContactServices
{
    public interface IContactServices 
    {
        Task<List<ResultContactDto>> GettAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}

using Ecommerce.Message.Dtos;

namespace Ecommerce.WebUI.Services.CatalogServices.MessageService
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendBoxMessageDto>> GetSendboxMessageAsync(string id);
        Task<int> GetTotalMessageCountByReceiverId(string id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}

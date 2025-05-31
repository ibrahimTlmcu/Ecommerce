using AutoMapper;
using Ecommerce.Message.DAL.Entities;
using Ecommerce.Message.Dtos;

namespace Ecommerce.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendBoxMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
        }
    }
   
}

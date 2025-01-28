using Ecommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using Ecommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;



namespace Ecommerce.Order.Application.Features.CQRS.Handlers.AddresHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;


        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommands createAddressCommand)
        {
            await _repository.CreatAsync(new Address
            {
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District,   
                UserId = createAddressCommand.UserId   
            });

        }

    }
}

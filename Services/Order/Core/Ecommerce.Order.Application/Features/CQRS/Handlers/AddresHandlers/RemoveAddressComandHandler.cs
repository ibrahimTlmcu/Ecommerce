using Ecommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using Ecommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Order.Application.Features.CQRS.Handlers.AddresHandlers
{
    public class RemoveAddressComandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressComandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(values);


        }

    }
}

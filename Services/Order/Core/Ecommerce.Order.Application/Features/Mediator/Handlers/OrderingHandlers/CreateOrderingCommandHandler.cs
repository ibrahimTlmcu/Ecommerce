using Ecommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Ecommerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommands>
    {
        private readonly IRepository<Ordering> _repository;


        public Task Handle(CreateOrderingCommands request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

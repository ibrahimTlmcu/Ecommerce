using Ecommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Ecommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailQueryHandler
    {
        public class UpdateOrderDetailCommandHandler
        {
            private readonly IRepository<OrderDetail> _repository;

            public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateOrderDetailCommand command)
            {
                var values = await _repository.GetByIdAsync(command.OrderDetailId);
                values.OrderDetailId = command.OrderDetailId;
                values.OrderingId = command.OrderingId;
                values.ProductId = command.ProductId;
                values.ProductPrice = command.ProductPrice;
                values.ProductName = command.ProductName;
                values.ProductTotalPrice = command.ProductTotalPrice;
                values.ProductAmount = command.ProductAmount;
                await _repository.UpdateAsync(values);



              
            }
        }
    }
}

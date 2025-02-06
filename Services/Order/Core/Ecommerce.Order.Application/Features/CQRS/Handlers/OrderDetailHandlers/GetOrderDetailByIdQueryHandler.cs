using Ecommerce.Order.Application.Features.CQRS.Queries.AddresQueires;
using Ecommerce.Order.Application.Features.CQRS.Queries.GetOrderDetailsQueries;
using Ecommerce.Order.Application.Features.CQRS.Results.AddressResults;
using Ecommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetOrderDetailByIdQuery = Ecommerce.Order.Application.Features.CQRS.Queries.GetOrderDetailsQueries.GetOrderDetailByIdQuery;

namespace Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductAmount   = values.ProductAmount,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                OrderingId  = values.OrderingId,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice   = values.ProductTotalPrice


            };

        }
    }
}

using Ecommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Ecommerce.Order.Application.Features.Mediator.Result.OrderingResults;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{//KONTROL ET
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdUserQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }


        async Task<GetOrderingByIdQueryResult> IRequestHandler<GetOrderingByIdUserQuery, GetOrderingByIdQueryResult>.Handle(GetOrderingByIdUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = values.OrderDate, 
                OrderingId = values.OrderingId,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId
            };
        }
    }
}

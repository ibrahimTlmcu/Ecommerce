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
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery,
        List<GetOrderingByUserIdQueryResult>>
    {
       private readonly IOrderingRepository _repository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetOrderingsByUserId(request.Id);

            var result = values.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();

            return result;
        }


    }
}

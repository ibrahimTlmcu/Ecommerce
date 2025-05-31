using Ecommerce.Order.Application.Features.Mediator.Result.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdUserQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; }
        public GetOrderingByIdUserQuery(int id)
        {
            Id = id;
        }

     
    }
}

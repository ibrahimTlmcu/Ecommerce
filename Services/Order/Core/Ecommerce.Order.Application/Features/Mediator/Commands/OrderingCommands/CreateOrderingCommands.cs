using Ecommerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommands :IRequest
    {
       
       
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

      
    }
}

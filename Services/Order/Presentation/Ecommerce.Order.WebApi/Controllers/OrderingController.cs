using Ecommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Ecommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Ecommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using Ecommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrderingById(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sparis basariyla silindi.");
        }
        [HttpPost]

        public async Task <IActionResult>CreateOrdering(CreateOrderingCommands command)
        {
            await _mediator.Send(command);
            return Ok("Sparıs onaylandı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sparis basariyla guncellendi");
        }

    }
}

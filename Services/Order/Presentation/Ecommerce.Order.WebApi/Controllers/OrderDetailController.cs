using Ecommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Ecommerce.Order.Application.Features.CQRS.Queries.GetOrderDetailsQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.UpdateOrderDetailQueryHandler;

namespace Ecommerce.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryhandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryhandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommanHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommanHandler;

        public OrderDetailController(GetOrderDetailQueryHandler getOrderDetailQueryhandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryhandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommanHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommanHandler)
        {
            _getOrderDetailQueryhandler = getOrderDetailQueryhandler;
            _getOrderDetailByIdQueryhandler = getOrderDetailByIdQueryhandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailCommanHandler = removeOrderDetailCommanHandler;
            _updateOrderDetailCommanHandler = updateOrderDetailCommanHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetaillist()
        {
            var values = await _getOrderDetailQueryhandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id )
        {
            var value = await _getOrderDetailByIdQueryhandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);

        }
        [HttpPost]
        public async Task <IActionResult> CreateOrderDetail(CreateOrderDetailCommands commands)
        {
            await _createOrderDetailCommandHandler.Handle(commands);    
            return Ok("Basariyla eklendi....");
        }

        [HttpDelete]

        public async Task <IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailCommanHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Basariyla silindi...");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommanHandler.Handle(command);
            return Ok("Guncelleme basarili...");

        }

    }

}

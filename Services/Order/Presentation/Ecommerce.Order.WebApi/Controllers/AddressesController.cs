using Ecommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using Ecommerce.Order.Application.Features.CQRS.Handlers.AddresHandlers;
using Ecommerce.Order.Application.Features.CQRS.Queries.AddresQueires;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;

        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressQueryHandler;
        private readonly RemoveAddressComandHandler _removeAddressComandHandler;




        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressByIdQueryHandler = null, UpdateAddressCommandHandler updateAddressByIdQueryHandler = null, RemoveAddressComandHandler removeAddressComandHandler = null)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressByIdQueryHandler;
            _updateAddressQueryHandler = updateAddressByIdQueryHandler;
            _removeAddressComandHandler = removeAddressComandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> AddressList()
        {
            var values = _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> AddressListById(int id )
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]

        public async Task <IActionResult> CreateAddress(CreateAddressCommands commands)
        {
            await _createAddressCommandHandler.Handle(commands);
            return Ok("Basariyla eklendi !!!!");
        }
        [HttpPut]

        public async Task <IActionResult> UpdateAddress(UpdateAddressCommand commands)
        {
            await _updateAddressQueryHandler.Handle(commands);
            return Ok("Basarili bir sekilde guncellendi");
        }

        [HttpDelete]

        public async Task <IActionResult> RemoveAddres(RemoveAddressCommand commands)
        {
            await _removeAddressComandHandler.Handle(commands);
            return Ok("Basarili bir sekilde silindi...");
        }

    }
}

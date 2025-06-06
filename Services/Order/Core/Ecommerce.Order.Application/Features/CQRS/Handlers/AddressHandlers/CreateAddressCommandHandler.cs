﻿using Ecommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using Ecommerce.Order.Domain.Entities;
using InterfacesRepository = Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ecommerce.Order.Application.Features.CQRS.Handlers.AddresHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly Ecommerce.Order.Application.Interfaces.IRepository<Address> _repository;


        public CreateAddressCommandHandler(Ecommerce.Order.Application.Interfaces.IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommands createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail1 = createAddressCommand.Detail1,
                District = createAddressCommand.District,   
                UserId = createAddressCommand.UserId, 
                Country = createAddressCommand.Country,
                Description = createAddressCommand.Description,
                Detail2 = createAddressCommand.Detail2,
                Email = createAddressCommand.Email,
                Name = createAddressCommand.Name,
                PhoneNumber = createAddressCommand.PhoneNumber,
                Surname = createAddressCommand.Surname,
                ZipCode = createAddressCommand.ZipCode




            });

        }

    }
}

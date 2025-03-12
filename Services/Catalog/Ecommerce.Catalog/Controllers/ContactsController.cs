using Ecommerce.Catalog.Dtos.ContactDtos;
using Ecommerce.Catalog.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactServices _ContactService;

        public ContactsController(IContactServices ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]

        public async Task<IActionResult> ContactList()
        {
            var values = await _ContactService.GettAllContactAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetContactById(string id)
        {
            var values = await _ContactService.GetByIdContactAsync(id);
            return Ok(values);
        }

        [HttpPost]
        //  Mapper kullandigimmi icin newleme yapmadan ekledik
        //  Contact ct = new Contact(); 

        //  ct.ContactName = createContact.name;

        //  gibi islemlerden kurutlduk 
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _ContactService.CreateContactAsync(createContactDto);
            return Ok("Contact islemi basariyla eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _ContactService.DeleteContactAsync(id);
            return Ok("Contact basariyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _ContactService.UpdateContactAsync(updateContactDto);
            return Ok("Contact basariyla guncellendi");
        }
    }
}

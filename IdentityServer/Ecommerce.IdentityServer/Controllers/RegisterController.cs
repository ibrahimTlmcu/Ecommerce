﻿using Ecommerce.IdentityServer.Dtos;
using Ecommerce.IdentityServer.Models;
using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Ecommerce.IdentityServer.Controllers
{
    [AllowAnonymous]

    //{
    //    [Authorize(LocalApi.PolicyName)]//IdentityServiceToken ile dogrulama sagliyoruz 
    [Route("api/[controller]")]
   
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                
            };
            var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
            
            if (result.Succeeded)
            {
                return Ok("Ekleme islemi basarili");
            }
            else
            {
                return Ok("Bir hata olustu");
            }
        }
    }
}

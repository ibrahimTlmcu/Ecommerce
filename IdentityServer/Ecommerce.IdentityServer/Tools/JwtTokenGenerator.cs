using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
            if (string.IsNullOrWhiteSpace(model.Id))
            {
                throw new ArgumentException("model.Id boş olamaz. Token üretilemez.");
            }else
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));
            }

                

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, model.Id)); // alt kimlik (sub), bazı yerler buradan alır
            if (!string.IsNullOrWhiteSpace(model.UserName))
                claims.Add(new Claim("UserName", model.UserName));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtToken =
                new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signInCredentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new TokenResponseViewModel(handler.WriteToken(jwtToken), expireDate);
        }
    }
}

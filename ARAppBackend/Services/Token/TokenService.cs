﻿using ARAppBackend.DTOs.User;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {

        public string CreateToken(UserEntity user)
        {
            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));

            //Claims headers
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.Firstname + "_" + user.Lastname),
                new Claim("role", user.Role),
                new Claim("uid", user.Id.ToString())

            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            //Token info
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "https://localhost:7016/",
                Issuer = "https://localhost:7016/",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

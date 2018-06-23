using Api.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.Extensions
{
    public static class Utils
    {
        public static SecurityToken CreateToken(this JwtSecurityTokenHandler jwtSecurityTokenHandler, 
            TokenConfigurations tokenConfigurations,
            SigningConfigurations signingConfigurations,
            ClaimsIdentity claimsIdentity)
        {
            DateCreate = DateTime.Now;
            DateExpiration = DateCreate + TimeSpan.FromSeconds(tokenConfigurations.Seconds);
            return jwtSecurityTokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = claimsIdentity,
                NotBefore = DateCreate,
                Expires = DateExpiration
            });
        }

        internal static DateTime DateCreate { get; set; }
        public static DateTime DateCreateToken(this JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            return DateCreate;
        }
        internal static DateTime DateExpiration { get; set; }
        public static DateTime DateExpirationToken(this JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            return DateExpiration;
        }
    }
}

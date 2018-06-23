using System;
namespace Api.Models
{
    public class TokenValidate
    {
        public bool Authenticated { get; }
        public DateTime DateCreated { get; }
        public DateTime DateExpiration { get; }
        public string Token { get; set; }
        public TokenValidate(bool authenticated, DateTime dateCreated, DateTime dateExpiration, string token)
        {
            Authenticated = authenticated;
            DateCreated = dateCreated;
            DateExpiration = dateExpiration;
            Token = token;
        }
        public static TokenValidate Create(bool authenticated, DateTime dateCreated, DateTime dateExpiration, string token)
            => new TokenValidate(authenticated, dateCreated, dateExpiration, token);
    }
}

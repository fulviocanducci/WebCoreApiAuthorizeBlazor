using System;
namespace Share
{
    public class TokenValidate
    {
        public int Authenticated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpiration { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }        

        public TokenValidate()
        {
        }

        public TokenValidate(int authenticated, string message)
        {
            Authenticated = authenticated;
            Message = message;
        }

        public TokenValidate(int authenticated, string message, DateTime dateCreated, DateTime dateExpiration, string token)
        {
            Authenticated = authenticated;
            Message = message;
            DateCreated = dateCreated;
            DateExpiration = dateExpiration;
            Token = token;
        }

        public static TokenValidate Create(int authenticated, string message)
            => new TokenValidate(authenticated, message);

        public static TokenValidate Create(int authenticated, string message, DateTime dateCreated, DateTime dateExpiration, string token)
            => new TokenValidate(authenticated, message, dateCreated, dateExpiration, token);
    }
}

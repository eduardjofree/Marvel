using System.Numerics;

namespace APIMarvel.src.Application.DTOs
{
    public class RequestUser
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public RequestUser(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

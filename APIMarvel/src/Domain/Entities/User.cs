using System.Numerics;

namespace APIMarvel.src.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Identificacion { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string nombre, string identificacion, string email, string password)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Email = email;
            Password = password;
        }
        private User() { }


        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}

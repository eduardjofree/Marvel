using System.Numerics;

namespace APIMarvel.src.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string nombre, string identificacion, string email, string password)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Email = email;
            Password = password;
        }
        public User() { }


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

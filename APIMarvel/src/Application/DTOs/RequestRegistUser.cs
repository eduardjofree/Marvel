using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIMarvel.src.Application.DTOs
{
    public class RequestRegistUser
    {
        public string Nombre { get; private set; }
        public string Identificacion { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public RequestRegistUser(string nombre, string identificacion, string email, string password)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Email = email;
            Password = password;
        }
    }
}

using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMarvel.src.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EncryptionService _encryptionService;

        public UserService(IUserRepository userRepository, EncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        public async Task<bool> AddUserAsync(User ObjUser)
        {
            // Verificar si el usuario ya existe por correo o identificación
            var existingUser = await _userRepository.ExistUserByEmailOrIdentAsync(ObjUser);

            if (existingUser != null)
            {
                return false; // Usuario ya existe
            }
            else
            {
                // Encriptar la contraseña
                string encryptedPassword = _encryptionService.Encrypt(ObjUser.Password);

                var user = new User
                {
                    Nombre = ObjUser.Nombre,
                    Identificacion = ObjUser.Identificacion,
                    Email = ObjUser.Email,
                    Password = encryptedPassword
                };

                await _userRepository.AddUserAsync(user);
                return true;
            }

        }

        public async Task<User> GetById(int userId)
        {
            return await _userRepository.GetById(userId);
        }
    }
}

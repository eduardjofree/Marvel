using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;

namespace APIMarvel.src.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<dynamic> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            var passwordFind = "";
            if (user != null)
            {
                passwordFind = user.Password;
            }
            
            if (user == null || user.Password != passwordFind) return null;
            return user;
        }

        public async Task<string> RequestPasswordResetAsync(string email)
        {
            return "RESET_TOKEN";
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            return true;
        }
    }
}

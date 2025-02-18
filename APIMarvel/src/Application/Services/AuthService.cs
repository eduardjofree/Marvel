using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtSettingsApp = APIMarvel.src.Domain.Entities.JwtSettings;

namespace APIMarvel.src.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettingsApp _jwtSettings;
        private readonly EncryptionService _encryptionService;
        public AuthService(IUserRepository userRepository, IOptions<JwtSettingsApp> jwtSettings, EncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
            _encryptionService = encryptionService;
        }

        public async Task<dynamic> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }
            else
            {
                // Desencriptar la contraseña
                string decryptedPassword = _encryptionService.Decrypt(user.Password);
                if (decryptedPassword != password)
                {
                    return null;
                }
                else
                {
                    var token = GenerateJwtToken(user);

                    return new AuthResponse
                    {
                        Token = token
                    };
                }
                
            }
           
        }

        public async Task<string> RequestPasswordResetAsync(string email)
        {
            return "RESET_TOKEN";
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            return true;
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Nombre),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                claims: claims,
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenDescriptor);
        }
    }
}

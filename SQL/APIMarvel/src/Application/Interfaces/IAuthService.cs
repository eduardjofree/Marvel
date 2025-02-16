namespace APIMarvel.src.Application.Interfaces
{
    public interface IAuthService
    {
        Task<dynamic> LoginAsync(string email, string password);
        Task<string> RequestPasswordResetAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
    }
}

using APIMarvel.src.Domain.Entities;

namespace APIMarvel.src.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int userId);
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User ObjtUser);
        Task<User> ExistUserByEmailOrIdentAsync(User ObjtUser);
    }
}

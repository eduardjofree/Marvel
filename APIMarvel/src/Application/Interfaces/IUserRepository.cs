using APIMarvel.src.Domain.Entities;

namespace APIMarvel.src.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int userId);
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
        Task UpdateAsync(User user);

        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        Task<dynamic> CreateUserAsync(User ObjtUser);
        Task<dynamic> UpdateUserAsync(User ObjtUser);
        Task<bool> DeleteUserAsync(User ObjtUser);
    }
}

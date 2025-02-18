using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using APIMarvel.src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace APIMarvel.src.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MarvelDbContext _context;
        public UserRepository(MarvelDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task AddUserAsync(User ObjUser)
        {
            await _context.Users.AddAsync(ObjUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> ExistUserByEmailOrIdentAsync(User ObjUser)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == ObjUser.Email || u.Identificacion == ObjUser.Identificacion);
        }

    }
}

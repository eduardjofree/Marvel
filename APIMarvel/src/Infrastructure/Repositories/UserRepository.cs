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

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // FUNCIONES NUEVAS

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task<dynamic> CreateUserAsync(User ObjUser)
        {
            var existRegist = _context.Users.FirstOrDefault(a => a.Email == ObjUser.Email);
            if (existRegist == null)
            {
                await _context.Users.AddAsync(ObjUser);
                await _context.SaveChangesAsync();
                return ObjUser;
            }
            else
            {
                return null;
            }

        }

        public async Task<dynamic> UpdateUserAsync(User ObjtUser)
        {
            var existRegist = _context.Users.FirstOrDefault(a => a.Id != ObjtUser.Id);
            if (existRegist == null)
            {
                _context.Entry(ObjtUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return ObjtUser;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> DeleteUserAsync(User ObjtUser)
        {
            //var entity = await GetByIdAsync(id);
            if (ObjtUser is null)
            {
                return false;
            }
            _context.Set<User>().Remove(ObjtUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

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

        public async Task<User> GetById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
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
            // Verificar si el usuario ya existe por correo o identificación
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == ObjUser.Email || u.Identificacion == ObjUser.Identificacion);

            if (existingUser != null)
            {
                return false; // Usuario ya existe
            }

            // Encriptar contraseña antes de guardarla
            //ObjUser.Password = BCrypt.Net.BCrypt.HashPassword(ObjUser.Password);

            // Guardar usuario en la base de datos
            _context.Users.Add(ObjUser);
            await _context.SaveChangesAsync();
            return true;

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

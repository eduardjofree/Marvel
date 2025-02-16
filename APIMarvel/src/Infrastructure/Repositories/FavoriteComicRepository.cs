using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using APIMarvel.src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace APIMarvel.src.Infrastructure.Repositories
{
    public class FavoriteComicRepository : IFavoriteComicRepository
    {
        private readonly MarvelDbContext _context;

        public FavoriteComicRepository(MarvelDbContext context)
        {
            _context = context;
        }

        public async Task<List<FavoriteComic>> GetFavoritesByUserAsync(int userId)
        {
            return await _context.FavoriteComics.Where(fc => fc.UserId == userId).ToListAsync();
        }

        public async Task AddFavoriteAsync(FavoriteComic favoriteComic)
        {
            await _context.FavoriteComics.AddAsync(favoriteComic);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteAsync(int userId, int comicId)
        {
            var favorite = await _context.FavoriteComics
                .FirstOrDefaultAsync(fc => fc.UserId == userId && fc.ComicId == comicId);

            if (favorite != null)
            {
                _context.FavoriteComics.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }
    }
}

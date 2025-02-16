using APIMarvel.src.Domain.Entities;

namespace APIMarvel.src.Application.Interfaces
{
    public interface IFavoriteComicRepository
    {
        Task<List<FavoriteComic>> GetFavoritesByUserAsync(int userId);
        Task AddFavoriteAsync(FavoriteComic favoriteComic);
        Task RemoveFavoriteAsync(int userId, int comicId);
    }
}

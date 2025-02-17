using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMarvel.src.Application.Services
{
    public class FavoriteComicService
    {
        private readonly IFavoriteComicRepository _favoriteComicRepository;
        private readonly IComicRepository _comicRepository; // Para verificar si el cómic existe

        public FavoriteComicService(IFavoriteComicRepository favoriteComicRepository, IComicRepository comicRepository)
        {
            _favoriteComicRepository = favoriteComicRepository;
            _comicRepository = comicRepository;
        }

        // Obtener los cómics favoritos de un usuario
        public async Task<List<Comic>> GetFavoritesByUserAsync(int userId)
        {
            var resultFavoriteComic = new List<FavoriteComic>();
            var resultListComicFavorite = new List<Comic>();
            resultFavoriteComic = await _favoriteComicRepository.GetFavoritesByUserAsync(userId);
            foreach (var item in resultFavoriteComic)
            {
                var resultComicInf = await _comicRepository.GetComicByIdAsync(item.ComicId);
                resultListComicFavorite.Add(resultComicInf);
            }
            return resultListComicFavorite;
        }

        // Agregar un cómic a favoritos
        public async Task<bool> AddFavoriteAsync(int userId, int comicId)
        {
            // Verificar si el cómic ya está en favoritos
            var existingFavorites = await _favoriteComicRepository.GetFavoritesByUserAsync(userId);
            if (existingFavorites.Any(fc => fc.ComicId == comicId))
                return false; // Ya está en favoritos

            // Verificar si el cómic existe en la base de datos
            var comic = await _comicRepository.GetComicByIdAsync(comicId);
            if (comic == null)
                return false; // El cómic no existe

            // Crear un nuevo favorito
            var favoriteComic = new FavoriteComic
            {
                UserId = userId,
                ComicId = comic.id
            };

            await _favoriteComicRepository.AddFavoriteAsync(favoriteComic);
            return true;
        }

        // Eliminar un cómic de favoritos
        public async Task<bool> RemoveFavoriteAsync(int userId, int comicId)
        {
            // Verificar si el cómic está en favoritos antes de eliminarlo
            var favorites = await _favoriteComicRepository.GetFavoritesByUserAsync(userId);
            if (!favorites.Any(fc => fc.ComicId == comicId))
                return false; // No está en favoritos

            await _favoriteComicRepository.RemoveFavoriteAsync(userId, comicId);
            return true;
        }
    }
}

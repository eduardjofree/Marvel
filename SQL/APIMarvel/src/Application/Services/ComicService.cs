using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;

namespace APIMarvel.src.Application.Services
{
    public class ComicService
    {
        private readonly IComicRepository _comicRepository;

        public ComicService(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }

        public async Task<List<Comic>> GetAllComicsAsync()
        {
            return await _comicRepository.GetAllComicsAsync();
        }

        public async Task<Comic> GetComicByIdAsync(int id)
        {
            return await _comicRepository.GetComicByIdAsync(id);
        }
    }  
}



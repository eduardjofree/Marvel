using APIMarvel.src.Domain.Entities;

namespace APIMarvel.src.Application.Interfaces
{
    public interface IComicRepository
    {
        Task<List<Comic>> GetAllComicsAsync();
        Task<Comic> GetComicByIdAsync(int id);
    }
}

using APIMarvel.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMarvel.src.Infrastructure.Data
{
    public class MarvelDbContext : DbContext
    {
        public MarvelDbContext(DbContextOptions<MarvelDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteComic> FavoriteComics { get; set; }
    }
}

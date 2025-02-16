namespace APIMarvel.src.Application.DTOs
{
    public class RequestFavoriteComic
    {
        public int UserId { get; private set; }
        public int ComicId { get; private set; }

        public RequestFavoriteComic(int userId, int comicId)
        {
            UserId = userId;
            ComicId = comicId;
        }
    }
}

using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using System.Text.Json;

namespace APIMarvel.src.Infrastructure.Repositories
{
    public class ComicRepository: IComicRepository
    {
        private readonly HttpClient _httpClient;
        private const string PublicKey = "174183e7c9d735f747d47e9e9f817a24";
        private const string PrivateKey = "ca0f814e5337bbdd3ff261847dc87e0d2029a9b6";
        private const string BaseUrl = "https://gateway.marvel.com/v1/public/comics";

        public ComicRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Comic>> GetAllComicsAsync()
        {
            string url = GenerateMarvelUrl();
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();
            var marvelResponse = JsonSerializer.Deserialize<MarvelComicResponse>(jsonString);
            return marvelResponse?.data?.results ?? new List<Comic>();
        }

        public async Task<Comic> GetComicByIdAsync(int id)
        {
            string url = $"{BaseUrl}/{id}{GenerateMarvelAuth()}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            var marvelResponse = JsonSerializer.Deserialize<MarvelComicResponse>(jsonString);

            return marvelResponse?.data?.results[0];
        }

        private string GenerateMarvelUrl()
        {
            return $"{BaseUrl}{GenerateMarvelAuth()}";
        }

        private string GenerateMarvelAuth()
        {
            string ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            string hash = GenerateMD5Hash(ts + PrivateKey + PublicKey);
            return $"?ts={ts}&apikey={PublicKey}&hash={hash}";
        }

        private static string GenerateMD5Hash(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}

// Modelos internos para deserializar JSON
internal class MarvelComicResponse
{
    public MarvelComicData data { get; set; }
}
//internal class MarvelComicResponse
//{
//    public dynamic data { get; set; }
//}

internal class MarvelComicData
{
    public List<Comic> results { get; set; }
}

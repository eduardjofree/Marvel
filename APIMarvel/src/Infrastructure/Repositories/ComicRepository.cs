using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using System.Text.Json;

namespace APIMarvel.src.Infrastructure.Repositories
{
    public class ComicRepository : IComicRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly string _baseUrl;

        public ComicRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _publicKey = configuration["marvelSettings:PublicKey"];
            _privateKey = configuration["marvelSettings:PrivateKey"];
            _baseUrl = configuration["marvelSettings:BaseUrl"];
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
            string url = $"{_baseUrl}/{id}{GenerateMarvelAuth()}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            var marvelResponse = JsonSerializer.Deserialize<MarvelComicResponse>(jsonString);

            return marvelResponse?.data?.results[0];
        }

        private string GenerateMarvelUrl()
        {
            return $"{_baseUrl}{GenerateMarvelAuth()}";
        }

        private string GenerateMarvelAuth()
        {
            string ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            string hash = GenerateMD5Hash(ts + _privateKey + _publicKey);
            return $"?ts={ts}&apikey={_publicKey}&hash={hash}";
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

internal class MarvelComicData
{
    public List<Comic> results { get; set; }
}

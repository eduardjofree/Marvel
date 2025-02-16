using System.Globalization;
using System.Text.Json.Serialization;
using static APIMarvel.src.Domain.Entities.Comic;

namespace APIMarvel.src.Domain.Entities
{
    public class Comic
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int issueNumber { get; set; }
        public int pageCount { get; set; }
        public string modified { get; set; }
        public string resourceURI { get; set; }
        public string ImageUrl => $"{thumbnail?.path}.{thumbnail?.extension}";
        public Thumbnail thumbnail { get; set; } = new Thumbnail();
        public List<TextObject> textObjects { get; set; } = new List<TextObject>();
        public List<Urls> urls { get; set; } = new List<Urls>();
        public Creators creators { get; set; } = new Creators();

        public class TextObject
        {
            public string type { get; set; }
            public string language { get; set; }
            public string text { get; set; }
        }

        public class Thumbnail
        {
            public string path { get; set; }
            public string extension { get; set; }
        }

        public class Creators
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public List<Items> items { get; set; } = new List<Items>();
        }

        public class Items
        {
            public string collectionURI { get; set; }
            public string name { get; set; }
            public string role { get; set; }
        }

        public class Urls
        {
            public string type { get; set; }
            public string url { get; set; }
        }
    }
}

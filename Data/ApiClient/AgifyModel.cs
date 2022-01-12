using System.Text.Json.Serialization;

namespace WordsBlazor.Data.ApiClient
{
    public class AgifyModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}

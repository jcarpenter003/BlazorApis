using System.Net.Http.Headers;
using System.Text.Json;

namespace WordsBlazor.Data.ApiClient
{
    public class ApiClient : IApiClient
    {
        public async Task<string> QueryApi(string name)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.agify.io?name={name}")
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var model = JsonSerializer.Deserialize<AgifyModel>(body);

                return model.Age.ToString();
            }
        }
    }
}

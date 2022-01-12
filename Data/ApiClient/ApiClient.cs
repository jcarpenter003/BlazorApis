using System.Net;
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
                if(response.IsSuccessStatusCode)
                {
                    try
                    {
                        var body = await response.Content.ReadAsStringAsync();

                        var model = JsonSerializer.Deserialize<AgifyModel>(body);

                        return model.Age.ToString();
                    }
                    catch (Exception ex)
                    {
                        return "Something went wrong";
                    }
                    
                }
                else if (response.StatusCode.Equals(HttpStatusCode.UnprocessableEntity))
                {
                    return "You did a bad input you silly goose";
                }
                else
                {
                    return "Something went wrong";
                }
               
            }
        }
    }
}

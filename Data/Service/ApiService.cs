using WordsBlazor.Data.ApiClient;

namespace WordsBlazor.Data.Service
{
    public class ApiService
    {
        private readonly IApiClient _summaryClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(IApiClient summaryClient, ILogger<ApiService> logger)
        {
            _summaryClient = summaryClient;
            _logger = logger;
        }

        public Task<string> QueryApi(string name)
        {
            var isNumeric = int.TryParse(name, out _);
            if (isNumeric) return Task.FromResult("Enter a valid name");

            return _summaryClient.QueryApi(name);
        }
    }
}

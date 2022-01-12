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
            // todo validate url

            return _summaryClient.QueryApi(name);
        }
    }
}

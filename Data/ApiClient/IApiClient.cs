namespace WordsBlazor.Data.ApiClient
{
    public interface IApiClient
    {
        Task<string> QueryApi(string url);
    }
}

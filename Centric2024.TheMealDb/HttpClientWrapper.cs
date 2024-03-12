namespace Centric2024.TheMealDb
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> GetAsync(string requestUrl)
        {
            return _httpClient.GetAsync(requestUrl);
        }
    }
}

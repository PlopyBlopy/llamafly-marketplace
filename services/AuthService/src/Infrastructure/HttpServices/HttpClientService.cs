namespace Infrastructure.HttpServices
{
    internal abstract class HttpClientService
    {
        protected internal HttpClient HttpClient { get; init; }

        protected HttpClientService(IHttpClientFactory httpClientFactory, string service)
        {
            HttpClient = httpClientFactory.CreateClient(service);
        }
    }
}
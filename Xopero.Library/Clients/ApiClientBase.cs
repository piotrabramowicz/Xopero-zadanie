using System.Net.Http.Headers;
using System.Text;

namespace Xopero.Library.Clients;

internal abstract class ApiClientBase
{
    private readonly HttpClient HttpClient = new();

    protected abstract string Token { get; }
    protected abstract string MediaType { get; }
    protected abstract string BaseUrl { get; }

    public ApiClientBase()
    {
        HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyApp", "1.0"));
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
    }

    protected async Task<bool> PostAsync(string requestUri, StringContent content)
    {
        var createResponse = await HttpClient.PostAsync(requestUri, content);

        return createResponse.IsSuccessStatusCode;
    }

    protected async Task<bool> PutAsync(string requestUri, StringContent content)
    {
        var createResponse = await HttpClient.PutAsync(requestUri, content);

        return createResponse.IsSuccessStatusCode;
    }

    protected async Task<bool> PatchAsync(string requestUri, StringContent content)
    {
        var createResponse = await HttpClient.PatchAsync(requestUri, content);

        return createResponse.IsSuccessStatusCode;
    }

    protected static StringContent CreateStringContent(string issue)
    {
        return new StringContent(issue, Encoding.UTF8, "application/json");
    }
}
using System.Net.Http.Headers;
using System.Text;

namespace Xopero.Library.Clients;

internal abstract class ApiClientBase
{
    private readonly HttpClient _httpClient = new();

    protected abstract string Token { get; }
    protected abstract string MediaType { get; }
    protected abstract string BaseUrl { get; }

    public ApiClientBase()
    {
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyApp", "1.0"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
    }

    protected async Task<bool> PostAsync(string requestUri, StringContent content)
    {
        var response = await _httpClient.PostAsync(requestUri, content);

        return response.IsSuccessStatusCode;
    }

    protected async Task<bool> PutAsync(string requestUri, StringContent content)
    {
        var response = await _httpClient.PutAsync(requestUri, content);

        return response.IsSuccessStatusCode;
    }

    protected async Task<bool> PatchAsync(string requestUri, StringContent content)
    {
        var response = await _httpClient.PatchAsync(requestUri, content);

        return response.IsSuccessStatusCode;
    }

    protected static StringContent CreateStringContent(string issue)
    {
        return new StringContent(issue, Encoding.UTF8, "application/json");
    }
}
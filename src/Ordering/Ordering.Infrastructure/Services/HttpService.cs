using System.Net.Http.Json;

namespace Ordering.Infrastructure.Services;
public class HttpService<T, TKey>(HttpClient client) : IHttpService<T, TKey>
    where T : BaseEntity<TKey>
{
    private readonly HttpClient _httpClient = client;

    public async Task Create(string url, T entity)
    {
        await _httpClient.PostAsJsonAsync(url, entity);
    }

    public async Task Delete(string url, T entity)
    {
        await _httpClient.DeleteAsync($"{url}/{entity.Id}");
    }

    public async Task<T?> Get(string url, TKey id)
    {
        var response = await _httpClient.GetFromJsonAsync<T>($"{url}/{id}");
        return response;
    }

    public async Task<IEnumerable<T?>> GetAll(string url)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<T>>(url);
        return response ?? [];
    }

    public async Task<bool> Update(string url, T entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"{url}/{entity.Id}", entity);
        return response.IsSuccessStatusCode;
    }
}

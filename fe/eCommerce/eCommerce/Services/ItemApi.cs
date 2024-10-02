using eCommerce.Model;
using Newtons oft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class ItemApi
{
    private readonly HttpClient _httpClient;
    public ItemApi()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Item> GetItemDetails(long id)
    {
        string url = $"http://172.29.224.1:8080/items/{id}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Item>(jsonResponse);
    }
}

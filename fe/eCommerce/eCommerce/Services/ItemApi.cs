using eCommerce.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class ItemApi
{
    private readonly HttpClient _httpClient;
    public ItemApi()
    {
        _httpClient = ApiConfig.GetClient();
    }

    public async Task<Item> GetItemDetails(long id)
    {
        string url = $"/items/{id}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Item>(jsonResponse);
    }
    public async Task<List<ItemsPreview>> GetItemBestSellingg()
    {
        string url = $"/items/best-selling";   
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<List<ItemsPreview>>(jsonResponse);
    }
    public async Task<List<ItemsPreview>> GetItemsRecommend()
    {
        string url = $"/items/recommended";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<List<ItemsPreview>>(jsonResponse);
    }
}

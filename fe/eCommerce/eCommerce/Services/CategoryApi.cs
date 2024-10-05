using eCommerce.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class CategoryApi
{
    private readonly HttpClient _httpClient;
    public CategoryApi()
    {
        _httpClient = ApiConfig.GetClient();
    }

    public async Task<List<Category>> GetCategories()
    {
        var response = await _httpClient.GetAsync("/category");
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Category>>(jsonResponse);
    }
    public async Task<List<Item>> GetItemsByCategoryId(long categoryId)
        {
            string url = $"/category/{categoryId}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Item>>(jsonResponse);
        }
}

using eCommerce.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class CategoryApi
{
    private readonly HttpClient _httpClient;
    public CategoryApi()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Category>> GetCategories()
    {
        string url = "http://172.29.224.1:8080/category";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Category>>(jsonResponse);
    }
}

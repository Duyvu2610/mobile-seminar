﻿using eCommerce.Model;
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
        _httpClient = new HttpClient();
    }

    public async Task<List<Category>> GetCategories()
    {
        string url = "http://192.168.171.1:8080/category";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Category>>(jsonResponse);
    }
    public async Task<List<Item>> GetItemsByCategoryId(long categoryId)
        {
            string url = $"http://192.168.171.1:8080/category/{categoryId}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Item>>(jsonResponse);
        }
}

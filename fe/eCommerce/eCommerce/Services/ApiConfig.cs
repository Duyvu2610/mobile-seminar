using System;
using System.Net.Http;
using System.Net.Http.Headers;

public class ApiConfig
{
    public ApiConfig()
    {
    }

    public static HttpClient GetClient()
    {
        HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://10.0.2.2:8080") // Đặt địa chỉ cơ sở  
        };
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return _httpClient;
    }
}
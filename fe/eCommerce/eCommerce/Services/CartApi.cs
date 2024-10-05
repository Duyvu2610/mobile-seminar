using eCommerce.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    class CartApi
    {
        private readonly HttpClient _httpClient;

        public CartApi()
        {
            _httpClient = ApiConfig.GetClient();
        }

        public async Task<List<CartModel>> GetCartList()
        {
            try
            {
                var response = await _httpClient.GetAsync("/cart");
                response.EnsureSuccessStatusCode(); 

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var cartList = JsonConvert.DeserializeObject<List<CartModel>>(jsonResponse);

                return cartList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; 
            }
        }

        public async Task<bool> AddToCart(CartModel cartItem)
        {
            try
            {
                string json = JsonConvert.SerializeObject(cartItem);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/cart", content);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding to cart: {ex.Message}");
                return false; 
            }
        }
    }
}

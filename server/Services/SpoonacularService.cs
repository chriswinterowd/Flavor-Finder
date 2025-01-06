using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlavorFinder.Models;
using Microsoft.Extensions.Configuration;

namespace FlavorFinder.Services
{
    public class SpoonacularService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey;

        public SpoonacularService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _apiKey = configuration["Spoonacular:ApiKey"];
        }

        public async Task<List<Recipe>> GetRandomRecipes(int number = 3)
        {
            var url = $"https://api.spoonacular.com/recipes/random?number={number}&apiKey={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to fetch recipes: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var spoonacularResponse = JsonSerializer.Deserialize<SpoonacularResponse>(json);

            return spoonacularResponse?.Recipes ?? new List<Recipe>();
        }
    }


}
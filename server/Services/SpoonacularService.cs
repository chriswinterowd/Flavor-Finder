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

        public async Task<List<Recipe>> GetRandomRecipes(int number = 1, string meal = "", string cuisine = "")
        {
            var baseUrl = "https://api.spoonacular.com/recipes/random";

            var tags = string.Join(",", new[] { meal, cuisine }.Where(tag => !string.IsNullOrWhiteSpace(tag)));
            Console.WriteLine("tags " + tags + " " + meal + cuisine + string.IsNullOrWhiteSpace(tags));
            var queryParams = $"number={number}" + (!string.IsNullOrWhiteSpace(tags) ? $"&include-tags={tags}" : "") + $"&apiKey={_apiKey}";

            var apiUrl = $"{baseUrl}?{queryParams}";

            Console.WriteLine(apiUrl);
            var response = await _httpClient.GetAsync(apiUrl);

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
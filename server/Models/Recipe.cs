using System.Text.Json.Serialization;

namespace FlavorFinder.Models
{
    public class Recipe
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("cuisines")]
        public List<string>? Cuisines { get; set; }

        [JsonPropertyName("dishTypes")]
        public List<string>? DishTypes { get; set; }

        [JsonPropertyName("extendedIngredients")]
        public List<Ingredient>? ExtendedIngredients { get; set; }

        [JsonPropertyName("analyzedInstructions")]
        public List<RecipeInstructions>? AnalyzedInstructions { get; set; }
    }

    public class SpoonacularResponse
    {
        [JsonPropertyName("recipes")]
        public List<Recipe>? Recipes { get; set; }
    }
    public class Ingredient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }
    }

    public class RecipeInstructions
    {
        [JsonPropertyName("steps")]
        public List<Instruction>? Steps { get; set; }
    }

    public class Instruction
    {
        [JsonPropertyName("number")]
        public int? Number { get; set; }

        [JsonPropertyName("step")]
        public string? Step { get; set; }
    }

}

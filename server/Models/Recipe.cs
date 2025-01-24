using System.ComponentModel.DataAnnotations;


namespace FlavorFinder.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int? ReadyInMinutes { get; set; }
        public int? Servings { get; set; }
        public string? Image { get; set; }
        public string? Summary { get; set; }
        public List<string> DishTypes { get; set; }

        [Required]
        public List<string> Cuisines { get; set; }

        public List<Ingredient> ExtendedIngredients { get; set; } = new List<Ingredient>();
        public List<RecipeInstructions> AnalyzedInstructions { get; set; } = new List<RecipeInstructions>();

    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string? Unit { get; set; }
        public string? Image { get; set; }
    }

    public class RecipeInstructions
    {
        public List<Instruction>? Steps { get; set; }
    }

    public class Instruction
    {
        public int? Number { get; set; }
        public string? Step { get; set; }
    }

    public class SpoonacularResponse
    {
        public List<Recipe>? Recipes { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FlavorFinder.Models.Entities
{
    public class RecipeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? ReadyInMinutes { get; set; }
        public int? Servings { get; set; }
        public string? Image { get; set; }
        public string? Summary { get; set; }



        [Required]
        public List<string> DishTypes { get; set; }

        [Required]
        public required List<string> Cuisines { get; set; }

        public ICollection<IngredientEntity> Ingredients { get; set; } = new List<IngredientEntity>();
        public required ICollection<InstructionEntity> Instructions { get; set; } = new List<InstructionEntity>();


    }
}
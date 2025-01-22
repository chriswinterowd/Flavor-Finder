namespace FlavorFinder.Models.Entities
{
    public class RecipeInstructionsEntity
    {
        public List<InstructionEntity>? Steps { get; set}
    }

    public class InstructionEntity
    {
        public int? Number { get; set; }
        public string? Step { get; set; }
    }
}
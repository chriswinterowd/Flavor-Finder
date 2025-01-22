namespace FlavorFinder.Models.Entities;
{
    public class IngredientEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Amount { get; set; }
    public string? Unit { get; set; }
    public string? Image { get; set; }
}
}
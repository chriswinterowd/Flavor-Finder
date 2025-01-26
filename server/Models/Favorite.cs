using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FlavorFinder.Models
{
    public class Favorite
    {

        public string UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
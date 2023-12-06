

namespace allspice_c.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Quantity { get; set; }
    public int RecipeId { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
}
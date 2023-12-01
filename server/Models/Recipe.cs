namespace allspice_c.Models;

public class Recipe
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Instructions { get; set; }
    public string Img { get; set; }
    public string CreatorId { get; set; }

    // FIXME change string to Profile when the time comes
    public Profile Creator { get; set; }
}
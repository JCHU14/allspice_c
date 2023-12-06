namespace allspice_c.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth0Provider;

    private readonly IngredientsService _ingredientsService;
    private readonly FavoritesService _favoritesService;



    public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider, IngredientsService ingredientsService, FavoritesService favoritesService)
    {
        _recipesService = recipesService;
        _auth0Provider = auth0Provider;
        _ingredientsService = ingredientsService;
        _favoritesService = favoritesService;

    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;

            Recipe recipe = _recipesService.CreateRecipe(recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }



    [HttpGet]
    public ActionResult<List<Recipe>> GetRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetRecipes();
            return Ok(recipes);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }




    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.GetRecipeById(recipeId);
            return Ok(recipe);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }



    [Authorize]
    [HttpDelete("{recipeId}")]
    public ActionResult<string> DeleteRecipe(int recipeId)
    {
        try
        {
            string message = _recipesService.DeleteRecipe(recipeId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }

    [Authorize]
    [HttpPut("{recipeId}")]
    public ActionResult<Recipe> UpdateRecipe(int recipeId, [FromBody] Recipe recipeData)
    {
        try
        {
            Recipe recipe = _recipesService.UpdateRecipe(recipeId, recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
            return Ok(ingredients);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }

    [HttpGet("{recipeId}/favorites")]
    public ActionResult<List<ProfileFavorites>> GetFavoritesByRecipeId(int recipeId)
    {
        try
        {
            List<ProfileFavorites> favorites = _favoritesService.GetFavoritesByRecipeId(recipeId);
            return Ok(favorites);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }

}
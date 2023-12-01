

namespace allspice_c.Services;


public class RecipesService
{
    private readonly RecipeRepository _recipeRepository;

    public RecipesService(RecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _recipeRepository.CreateRecipe(recipeData);

        return recipe;
    }

    internal string DeleteRecipe(int recipeId)
    {
        Recipe recipe = GetRecipeById(recipeId);

        _recipeRepository.DeleteRecipe(recipeId);

        return $"{recipe} Recipe has been deleted!";
    }



    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _recipeRepository.GetRecipeById(recipeId);

        if (recipe == null)
        {
            throw new Exception($"Invalid ID: {recipeId}");
        }
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _recipeRepository.GetRecipes();

        return recipes;
    }



    internal Recipe UpdateRecipe(int recipeId, Recipe recipeData)
    {
        Recipe ogRecipe = GetRecipeById(recipeId);

        ogRecipe.Title = recipeData.Title ?? ogRecipe.Title;
        ogRecipe.Category = recipeData.Category ?? ogRecipe.Category;
        ogRecipe.Img = recipeData.Img ?? ogRecipe.Img;
        ogRecipe.Instructions = recipeData.Instructions ?? ogRecipe.Instructions;

        _recipeRepository.UpdateRecipe(ogRecipe);

        return ogRecipe;
    }
}
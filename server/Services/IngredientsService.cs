



namespace allspice_c.Services
{
    public class IngredientsService
    {

        private readonly IngredientRepository _repository;

        public IngredientsService(IngredientRepository repository)
        {
            _repository = repository;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            Ingredient ingredient = _repository.CreateIngredient(ingredientData);
            return ingredient;
        }

        internal string DeleteIngredient(int ingredientId, string userId)
        {
            Ingredient ingredient = GetIngredientById(ingredientId);
            if (ingredient.CreatorId != userId)
            {
                throw new Exception("NOT YOUR INGREDIENT");
            }
            _repository.DeleteIngredient(ingredientId);
            return "ingredient was deleted";
        }

        internal Ingredient GetIngredientById(int ingredientId)
        {
            Ingredient ingredient = _repository.GetIngredientById(ingredientId);
            if (ingredient == null)
            {
                throw new Exception($"Invalid Id");
            }
            return ingredient;
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            List<Ingredient> ingredients = _repository.GetIngredientByRecipeId(recipeId);
            return ingredients;
        }
    }
}





namespace allspice_c.Services
{
    public class FavoritesService
    {

        private readonly FavoritesRepository _repository;

        public FavoritesService(FavoritesRepository repository)
        {
            _repository = repository;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repository.CreateFavorite(favoriteData);
            if (favorite == null)
            {
                throw new Exception("Invalid Id");
            }
            return favorite;
        }

        internal string DeleteFavorite(int favoriteId, string userId)
        {
            Favorite favorite = GetFavoriteById(favoriteId);
            if (favorite.AccountId != userId)
            {
                throw new Exception("NOT YOUR FAVORITE");
            }
            _repository.DeleteFavorite(favoriteId);
            return "Deleted Favorite";
        }

        internal Favorite GetFavoriteById(int favoriteId)
        {
            Favorite favorite = _repository.GetFavoritesById(favoriteId);
            if (favorite == null)
            {
                throw new Exception("Invalid Id");
            }
            return favorite;
        }

        internal List<FavoriteRecipe> GetRecipeFavoritesByAccountId(string userId)
        {
            List<FavoriteRecipe> favoriteRecipes = _repository.GetRecipeFavoritesByAccountId(userId);
            return favoriteRecipes;
        }

        internal List<ProfileFavorites> GetFavoritesByRecipeId(int recipeId)
        {
            List<ProfileFavorites> favorites = _repository.GetFavoritesByRecipeId(recipeId);
            return favorites;
        }

    }
}
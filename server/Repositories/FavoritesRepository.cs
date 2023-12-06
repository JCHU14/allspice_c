


namespace allspice_c.Repositories
{
    public class FavoritesRepository
    {

        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }





        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO
            favorites(recipeId, accountId)
            VALUES(@RecipeId, @AccountId)
            
            SELECT * FROM favorites WHERE id = LAST_INSERT_ID();";

            Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();

            return favorite;
        }







        internal void DeleteFavorite(int favoriteId)
        {
            string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIt 1;";
            _db.Execute(sql, new { favoriteId });
        }







        internal Favorite GetFavoritesById(int favoriteId)
        {
            string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";

            Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
            return favorite;
        }






        internal List<ProfileFavorites> GetFavoritesByRecipeId(int recipeId)
        {
            string sql = @"
            SELECT
            favor.*,
            acc.*
            FROM favorites favor
            JOIN accounts acc On acc.id = favor.accountId
            WHERE favor.recipeId = @recipeId;";

            List<ProfileFavorites> favorites = _db.Query<Favorite, ProfileFavorites, ProfileFavorites>(sql, (favorite, profileFavorite) =>
            {
                profileFavorite.FavoriteId = favorite.Id;
                profileFavorite.RecipeId = favorite.RecipeId;
                return profileFavorite;
            }, new { recipeId }).ToList();
            return favorites;
        }





        internal List<FavoriteRecipe> GetRecipeFavoritesByAccountId(string userId)
        {
            string sql = @"
            SELECT
            favor.*,
            rec.*,
            acc.*
            FROM favorites favor
            JOIN recipes rec ON favor.recipeId = rec.id
            JOIN accounts acc ON acc.id = rec.creatorId
            WHERE favor.accountId = @userId;";

            List<FavoriteRecipe> favoriteRecipes = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>
            (sql, (favorite, favoriteRecipe, profile) =>
            {
                favoriteRecipe.FavoriteId = favorite.Id;
                favoriteRecipe.AccountId = favorite.AccountId;
                favoriteRecipe.Creator = profile;
                return favoriteRecipe;
            }, new { userId }).ToList();
            return favoriteRecipes;
        }


    }
}
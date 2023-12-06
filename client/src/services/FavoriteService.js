import { AppState } from "../AppState"
import { logger } from "../utils/Logger"


    class FavoriteService{

        async favoriteRecipe(recipeId) {
            const favData = {}
            favData.recipeId = recipeId
            const favorite = await api.post('api/favorites', favData)
            Pop.toast(`You have favorited this recipe!`)
            AppState.favorites.push(favorite)
        }

        async getFavoritesByAccountId(){
            const res = await api.get(`account/favorites`)
            logger.log( 'My favorites',res.data)
            const newFavs = res.data.map((favs) => new Favorite(favs))
            AppState.favorites = newFavs
            logger.log('These Is are Favorites in your AppState',AppState.favorites)
        }

        async removeFavorite(favoriteId) {
            const res = await api.delete(`api/favorites/${favoriteId}`)
            AppState.favorite = AppState.favorite.filter(
                (favorite) => favorite.id != favoriteId
            );
            logger.log(res.data)
        }
    }

    export const favoriteService = new FavoriteService();
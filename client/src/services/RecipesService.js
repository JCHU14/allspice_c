import { AppState } from "../AppState";
import { Recipe } from "../models/Recipe";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";




    class RecipesService{

        async getRecipes(){
            const res = await api.get(`api/recipes`)
            logger.log(res.data)
            AppState.recipes = res.data.map((recipe) => new Recipe(recipe))
            logger.log (AppState.recipes)
        }

        async createRecipe(recipeData) {
            const res = await api.post('api/recipes', recipeData)
            logger.log('creating recipe', res.data)
            const newRecipe = new Recipe(res.data)
            AppState.recipes.push(newRecipe)
            return newRecipe;
        }

        async destroyRecipe(recipeId) {
            const res = await api.delete(`api/recipes/${recipeId}`);
            logger.log("recipe Deleted", res.data);
            AppState.activeRecipe = new Recipe(res.data);
          
        }

        async editRecipe(recipeId, recipeData) {
            const res = await api.put(`api/recipes/${recipeId}`, recipeData)
            logger.log('you edited recipe', res.data)
            const newRecipe = new Recipe(res.data)
            AppState.activeRecipe = newRecipe
          }

          async getRecipeById(recipeId) {
            AppState.activeRecipe = null;
            const res = await api.get(`api/recipes/${recipeId}`);
            logger.log("got recipe by ID", res.data);
            AppState.activeRecipe = new Recipe(res.data);
          }
    }

    export const recipesService = new RecipesService();
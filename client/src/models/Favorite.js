export class Favorite {
    constructor(data){
       this.recipe = data.recipe ? data.recipe : null
       this.recipeId = data.recipeId
       this.id = data.id
       this.accountId = data.accountId
       this.account = data.account
    }
}

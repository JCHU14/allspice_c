
    export class Ingredient{
        constructor(data){
            this.id = data.id
            this.name = data.name
            this.quantity = data.quantity
            this.recipeId = data.recipeId
            this.createdAt = new Date(data.createdAt)
            this.updatedAt = new Date(data.updatedAt)
            this.creator = data.creator
            this.creatorId = data.creatorId
        }
    }
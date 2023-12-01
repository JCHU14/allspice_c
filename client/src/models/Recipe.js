

    export class Recipe{
        constructor(data){
            this.title = data.title
            this.category = data.category
            this.instructions = data.instructions
            this.id = data.id
            this.creator = data.creator
            this.img = data.img
            this.creatorId = data.creatorId
            this.createdAt = new Date(data.createdAt)
            this.updatedAt = new Date(data.updatedAt)
        }
    }
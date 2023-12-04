<template>
    <div class="modal fade" id="createModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header green">
                    <p class="fs-1 align-items-center display-2 text-light">Create Recipe</p>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="container-fluid">

                    <div>
                        <form @submit.prevent="createRecipe()">


                            <div class="d-flex justify-content-around">

                                <div class="mb-3">
                                    <label for="title" class="form-label text-center text-dark fs-2">Title</label>
                                    <textarea v-model="editable.title" maxlength="45" class="form-control" id="title"
                                        required rows="1"></textarea>
                                </div>

                                <div class="mb-3">
                                    <label for="category" class="form-label text-center text-dark fs-2">Category</label>
                                    <textarea v-model="editable.category" maxlength="10" class="form-control" id="category"
                                        required rows="1"></textarea>
                                </div>

                            </div>



                            <div class="text-end">
                                <button class="btn btn-success" type="submit">Submit</button>
                            </div>
                        </form>
                    </div>

                </div>

            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { recipesService } from '../services/RecipesService';
import { AppState } from '../AppState';





export default {
    setup() {
        const editable = ref({})

        return {
            editable,
            recipes: computed(() => { AppState.recipes }),
            async createRecipe() {
                try {
                    const recipeData = editable.value
                    await recipesService.createRecipe(recipeData)

                    editable.value = {}

                    Modal.getOrCreateInstance('#createModal').hide()
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};
</script>


<style lang="scss" scoped>
.titles {
    background-color: rgba(128, 128, 128, 0.26);
}

.green {
    background-color: darkgreen;
}

.underline {
    text-decoration: 2px underline black;
}

.box-shadow {
    box-shadow: 0 5px 10px black;
}
</style>
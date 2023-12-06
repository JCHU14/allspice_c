<template>
    <div class="modal fade" id="largeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header text-end justify-content-end">
                    <div class="justify-content-end">
                        <button @click="deleteRecipe(activeRecipe.id)" class="bg-danger text-centers fs-4"><i
                                class="mdi mdi-trash-can"></i></button>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                </div>

                <div v-if="recipes" class="modal-body">
                    <div class="container-fluid">
                        <div class="row">

                            <div class="col-md-5 col-12">
                                <img class="img-fluid box-shadow" :src="recipes.img" alt="">
                            </div>

                            <div class="col-md-7 col-12 my-2">

                                <div class="d-flex justify-content-around">
                                    <p class="fs-3 display-5 underline">{{ recipes.title }}</p>
                                    <p class="titles rounded fs-5 p-1 text-dark">{{ recipes.category }}</p>

                                </div>

                                <section class="row my-5 justify-content-around">

                                    <div class="col-md-5 col-12 text-center">
                                        <p class="fs-3 green text-light rounded">Ingredients</p>

                                    </div>

                                    <div class="col-md-5 col-12 text-center">
                                        <div class="titles box-shadow">
                                            <p class="fs-2 green text-light">Recipe Steps</p>
                                            <p class="fs-3 my-3 p-2">{{ recipes.instructions }}</p>
                                            <form class="p-2" v-if="account?.id == recipes?.creator?.id"
                                                @submit.prevent="editRecipe(activeRecipe.id)">


                                                <label for="instructions" class="form-label">Edit
                                                    instructions</label>

                                                <div class="mb-3 d-flex text-center justify-content-center">

                                                    <div>
                                                        <textarea v-model="editable.instructions" maxlength="100"
                                                            class="form-control" id="instructions" required
                                                            rows="1"></textarea>
                                                    </div>

                                                    <div class="text-center">
                                                        <button class="btn green" type="submit">+</button>
                                                    </div>
                                                </div>



                                            </form>
                                        </div>
                                    </div>
                                </section>


                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
</template>


<script>

import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { Modal } from 'bootstrap';


export default {
    setup() {
        const editable = ref({})


        return {
            recipes: computed(() => AppState.activeRecipe),
            account: computed(() => AppState.account),
            activeRecipe: computed(() => AppState.activeRecipe),
            editable,

            async editRecipe(recipeId) {
                try {
                    const recipeData = editable.value;
                    logger.log("editing recipe", recipeData);
                    await recipesService.editRecipe(recipeId, recipeData);
                } catch (error) {
                    logger.error("edit recipe error", error);
                    Pop.error("recipe error", error.message);
                }
            },

            async deleteRecipe(recipeId) {
                try {
                    const yes = await Pop.confirm(`Are you sure you want to delete this recipe?`);
                    if (!yes) {
                        return;
                    }
                    await recipesService.destroyRecipe(recipeId);
                    Modal.getOrCreateInstance('#largeModal').hide()
                }
                catch (error) {
                    Pop.error;
                }
            },
        };
    },
};
</script>


<style lang="scss" scoped>
.titles {
    background-color: rgba(128, 128, 128, 0.26);
}

.green {
    background-color: green;
}

.underline {
    text-decoration: 2px underline black;
}

.box-shadow {
    box-shadow: 0 5px 10px black;
}
</style>
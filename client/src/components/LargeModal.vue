<template>
    <div class="modal fade" id="largeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div v-if="recipes" class="modal-body">
                    <div class="container-fluid">
                        <div class="row">

                            <div class="col-5">
                                <img class="img-fluid" :src="recipes.img" alt="">
                            </div>

                            <div class="col-7">

                                <div class="d-flex justify-content-around">
                                    <p class="fs-3 display-5">{{ recipes.title }}</p>
                                    <p class="titles rounded fs-5 p-1 text-dark">{{ recipes.category }}</p>
                                </div>

                                <section class="row my-5 justify-content-around">

                                    <div class="col-5 text-center">
                                        <p class="fs-3 bg-success rounded">Ingredients</p>

                                    </div>

                                    <div class="col-5 text-center">
                                        <div class="titles box-shadow">
                                            <p class="fs-2 bg-success">Recipe Steps</p>
                                            <p class="fs-3 my-3 p-2">{{ recipes.instructions }}</p>
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

import { computed } from 'vue';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe';


export default {
    setup() {


        return {
            recipes: computed(() => AppState.activeRecipe)
        };
    },
};
</script>


<style lang="scss" scoped>
.titles {
    background-color: rgba(128, 128, 128, 0.26);
}

.box-shadow {
    box-shadow: 0 5px 10px black;
}
</style>
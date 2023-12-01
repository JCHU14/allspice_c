<template>
    <div @click="setActiveRecipe(recipeProp)" class="container-fluid background-recipe glow"
        :style="{ backgroundImage: `url('${recipeProp.img}')` }">

        <section class="row">

            <div class="d-flex justify-content-between my-2 text-light">
                <p class=" fs-5 titles text-center col-6 rounded ">{{ recipeProp.category }}</p>
                <button class=" col-2 btn titles text-light"><i class="mdi mdi-heart"></i></button>
            </div>

            <div type="button" role="button" data-bs-toggle="modal" data-bs-target="#largeModal">

                <div class="my-5">
                    <div class="titles rounded text-light">
                        <p class="fs-5">{{ recipeProp.title }}</p>
                        <p class="fs-5">{{ recipeProp.instructions }}</p>
                    </div>
                </div>

            </div>


        </section>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
export default {
    props: { recipeProp: { type: Recipe, required: true } },

    setup(props) {

        return {
            backgroundImg: computed(() => props.recipeProp.img),

            async setActiveRecipe(recipeData) {
                try {
                    logger.log(recipeData)
                    AppState.activeRecipe = {}
                    AppState.activeRecipe = recipeData
                    Modal.getOrCreateInstance('#largeModal').hide()
                } catch (error) {
                    Pop.error
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped>
.background-recipe {
    // background-image: url(v-bind(backgroundImg));
    background-position: center;
    background-size: cover;
    background-repeat: no-repeat;
    border: 5px solid black;
    height: 35vh;
    width: 100%;
}

.glow:hover {
    box-shadow: 0px 0px 50px green;
    transition: ease-in-out 0.3s;
}

.titles {
    background-color: rgba(128, 128, 128, 0.767);
}
</style>
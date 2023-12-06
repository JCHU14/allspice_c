<template>
  <div class="container-fluid">

    <div class="row background-pic">

      <div class="text-end p-2">
        <Login />
      </div>

      <div class="col-12 my-5">
        <p class=" display-3 text-center text">All-Spice</p>
        <p class=" display-6 text-center text">Cherish Your Family</p>
        <p class=" display-6 text-center text">And Their Cooking</p>
      </div>

      <div class="col-12 d-flex justify-content-center">
        <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
          <button class="btn btn-white m-2 fs-4 box-shadow glow2">Home</button>
        </router-link>
        <button @click="getRecipesByAccount(recipes.id)" class="btn btn-white m-2 fs-4 box-shadow glow2">My
          Recipes</button>
        <button class="btn btn-white m-2 fs-4 box-shadow glow2">Favorites</button>
      </div>

    </div>




    <div class="row justify-content-around">
      <div class=" col-12 col-md-3 m-3" v-for="recipe in recipes" :key="recipe">
        <RecipeComp :recipeProp="recipe" />
      </div>
    </div>

  </div>
  <CreateRecipeModal />
</template>

<script>
import { computed, onMounted } from 'vue';
import { recipesService } from '../services/RecipesService';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import RecipeComp from '../components/RecipeComp.vue';
import LargeModal from '../components/LargeModal.vue';
import CreateRecipeModal from '../components/CreateRecipeModal.vue';
import Login from '../components/Login.vue';
import { accountService } from '../services/AccountService.js';
import { useRoute } from 'vue-router';

export default {
  setup() {
    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error;
      }
    }


    const route = useRoute();


    return {
      recipes: computed(() => AppState.recipes),
      account: computed(() => AppState.account),

      async getRecipesByAccount(accountId) {
        try {
          const accountId = route.params.accountId;
          await accountService.getRecipesByAccount(accountId)
        }
        catch (error) {
          Pop.error(error);
        }
      },
    };
  },
  components: { RecipeComp, LargeModal, CreateRecipeModal, Login }
}
</script>

<style scoped lang="scss">
.background-pic {
  background-image: url(https://images.unsplash.com/photo-1470549813517-2fa741d25c92?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y29va2luZyUyMGluZ3JlZGllbnRzfGVufDB8fDB8fHww);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  border: 10px solid white;
}

.glow:hover {
  box-shadow: 0px 0px 50px green;
  transition: ease-in-out 0.3s;
}

.glow2:hover {
  box-shadow: 0px 0px 50px gold;
  transition: ease-in-out 0.3s;
}

.box-shadow {
  box-shadow: 0 5px 10px black;
}

.text {
  text-shadow: 2px 2px 5px black;
  color: white;
}
</style>

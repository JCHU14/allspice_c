<template>
  <main>
    <router-view />
  </main>
  <footer class="p-4 container-fluid sticky-bottom d-flex justify-content-end">
    <div class="row">
      <p type="button" data-bs-toggle="modal" data-bs-target="#createModal"
        class="col-12 green text-light rounded-circle fs-1"><i class="mdi mdi-leaf"></i></p>
    </div>
  </footer>
  <LargeModal />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import LargeModal from './components/LargeModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, LargeModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  // height: 32px;
}

.green {
  background-color: green;
}
</style>

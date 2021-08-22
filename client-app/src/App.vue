<template>
    <div class="h-100 d-flex flex-column">
      <div v-if="!$route.path.includes('login')" class="d-flex p-1 justify-content-end">
        <b-button @click="logOut()">Logout</b-button>
      </div>
      <router-view></router-view>
    </div>
</template>

<script>
export default {
  name: 'App',
  methods: {
    logOut() {
      localStorage.clear();
      this.$router.push({name: 'login'});
    }
  }
}
</script>

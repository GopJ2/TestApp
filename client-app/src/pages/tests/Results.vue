<template>
  <div class="h-100 d-flex justify-content-center flex-column align-items-center">
    <div class="d-flex justify-content-center flex-column align-items-center" v-if="result">
      <span>Test id : {{ result.id }}</span>
      <span>{{result.correctAnswers}} / {{result.questions}}</span>
      <router-link class="link-info page-link" to="/tests">Back to tests</router-link>
    </div>
    <div v-else>
        <span>No results yet. Please start the test</span>
    </div>
  </div>
</template>

<script>
import {mapGetters} from 'vuex';
export default {
  name: "Results",
  data() {
    return {
      result: {},
    }
  },
  computed: {
    ...mapGetters('testResult', [
      'getTestResultById'
    ])
  },
  created() {
    this.result = this.getTestResultById(this.$route.params.id)
  }
}
</script>
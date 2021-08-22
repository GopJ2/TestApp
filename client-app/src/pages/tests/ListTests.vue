<template>
  <div class="h-100 container-md w-75 d-flex align-items-center justify-content-center">
    <div v-for="test in tests" :key="test.id">
      <b-list-group >
        <b-list-group-item class="w-100">
          <span>{{test.id}}</span>
          <b-button variant="success" @click="$bvModal.show('modal-test-desc')">Start</b-button>
        </b-list-group-item>
      </b-list-group>

      <b-modal id="modal-test-desc" title="Test agreement" hide-footer hide-header>
        <p class="my-4">{{ test.description }}</p>
        <b-form-checkbox
            id="checkbox-1"
            v-model="status"
            name="checkbox-1"
            value=1
            unchecked-value=0
        >
          I agree to start
        </b-form-checkbox>
        <span v-if="modalError" class="text-danger">{{modalError}}</span>
        <b-button variant="success" @click="proceed(test)">Proceed</b-button>
      </b-modal>
    </div>
  </div>
</template>

<script>
import api from "../../services/api";
export default {
  data() {
    return {
      tests: [],
      status: 0,
      modalError: '',
    }
  },
  async created() {
    this.tests = (await api.get('/Test/tests')).data;
  },
  methods: {
    proceed(test) {
      if (this.status === "1") {
        this.status = 0;
        this.modalError = '';
        this.$bvModal.hide("modal-test-desc");
        this.$router.push(`/tests/${test.id}`);
        return;

        //GO TO VUEX save id => checked. After will check if agreement was accepted before route.
      }

      this.modalError = "Agreement needs to be checked";
    },
  },
  name: "ListTests"
}
</script>

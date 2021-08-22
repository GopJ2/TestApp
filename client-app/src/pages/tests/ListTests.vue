<template>
  <div class="h-100 container-md w-75 d-flex flex-column overflow-auto align-items-center justify-content-center">
    <template v-if="tests.length > 0">
      <p class="my-4">Available tests</p>
      <div class="w-50" v-for="test in tests" :key="test.id">
        <b-list-group >
          <b-list-group-item class="w-100 d-flex justify-content-between align-items-center">
            <span>{{test.name}}</span>
            <b-button variant="success" @click="showModal(test)">Start</b-button>
          </b-list-group-item>
        </b-list-group>
      </div>
      <b-modal id="modal-test-desc" title="Test agreement" hide-footer hide-header>
        <p class="my-4">{{ selectedTest ? selectedTest.description : ''}}</p>
        <b-form-checkbox
            id="checkbox-1"
            v-model="status"
            name="checkbox-1"
            value=1
            unchecked-value=0
        >
          I agree to start
        </b-form-checkbox>
        <div class="d-flex flex-column">
          <span v-if="modalError" class="text-danger">{{modalError}}</span>
          <b-button variant="success" @click="proceed">Proceed</b-button>
        </div>
      </b-modal>
    </template>
    <template v-else>
        <p class="my-4">There are no tests for you yet :)</p>
    </template>
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
      selectedTest: null,
    }
  },
  async created() {
    this.tests = (await api.get('/Test/tests')).data;
  },
  methods: {
    proceed() {
      if (this.status === "1") {
        this.status = 0;
        this.modalError = '';
        this.$bvModal.hide("modal-test-desc");
        this.$router.push(`/tests/${this.selectedTest.id}`);
        return;
      }

      this.modalError = "Agreement needs to be checked";
    },
    showModal(test) {
      this.selectedTest = test;
      this.$bvModal.show('modal-test-desc');
    }
  },
  name: "ListTests"
}
</script>

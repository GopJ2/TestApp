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
            @change="agreementChange"
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
import {mapActions, mapGetters} from 'vuex';
export default {
  data() {
    return {
      status: false,
      modalError: '',
      selectedTest: null,
    }
  },
  async created() {
    await this.loadTests();
  },
  methods: {
    ...mapActions({
      loadTests: 'tests/loadTests',
      changeAgreement: 'tests/acceptTestAgreement',
    }),
    proceed() {
      if (this.status) {
        this.status = false;
        this.modalError = '';
        this.$bvModal.hide("modal-test-desc");
        this.$router.push(`/tests/${this.selectedTest.id}`);
        return;
      }

      this.modalError = "Agreement needs to be checked";
    },
    agreementChange(e) {
      this.status = e;
      this.changeAgreement({testId: this.selectedTest.id, checked: e});
    },
    showModal(test) {
      this.selectedTest = test;
      this.$bvModal.show('modal-test-desc');
    }
  },
  computed: {
    ...mapGetters({
      tests: 'tests/tests'
    })
  },
  name: "ListTests"
}
</script>

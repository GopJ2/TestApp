<template>
  <div class="h-100 container-md w-50 d-flex flex-column justify-content-center">
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" align-v="center">
      <b-form-group
          id="input-group-1"
          label="Email address:"
          label-for="input-1"
          class="m-2"
      >
        <b-form-input
            id="input-1"
            v-model="form.email"
            type="email"
            placeholder="Enter email"
            required
        ></b-form-input>
      </b-form-group>

      <b-form-group class="m-2" id="input-group-2" label="Your password:" label-for="input-2">
        <b-form-input
            id="input-2"
            v-model="form.password"
            placeholder="Enter password"
            required
        ></b-form-input>
      </b-form-group>
      <div v-if="errorMessage" class="text-danger float-end">
        {{ errorMessage }}
      </div>
      <b-button class="m-2" type="submit" variant="primary">Submit</b-button>
      <b-button class="m-2" type="reset" variant="danger">Reset</b-button>
    </b-form>

  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      form: {
        email: '',
        password: '',
      },
      show: true,
      errorMessage: '',
    }
  },
  methods: {
    async onSubmit(event) {
      event.preventDefault()
      try {
        const result = await axios.post('https://localhost:44381/api/Auth/login', this.form);
        console.log(result);

      } catch(e) {
        this.errorMessage = e.response.data;
      }
    },
    onReset(event) {
      event.preventDefault()
      this.form.email = '';
      this.form.password = '';
      this.errorMessage = '';
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      })
    }
  }
}
</script>

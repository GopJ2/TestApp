<template>
  <div>
      <b-list-group >
        <b-list-group-item class="w-100 border-primary">
          <span>{{questionText}}</span>
        </b-list-group-item>
      </b-list-group>
    <div class="w-100 mt-5">
      <div class="w-100" v-for="(option, i) in answers" :key="option.id">
        <b-list-group>
          <b-list-group-item class="w-100 mt-1 d-flex flex-row align-items-center border-secondary justify-content-between">
            <span>{{option.answerText}}</span>
            <input class="m-2" type="checkbox" @click="setChecked(option, i)" :checked="i === checked" :id="option.id">
          </b-list-group-item>
        </b-list-group>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    questionText: {
      type: String,
      required: true
    },
    answers: {
      type: Array,
      required: true
    },
  },
  data() {
    return {
      options: [],
      checked: null,
    }
  },
  methods: {
    setChecked(answer, i) {
      this.checked = this.checked === i ? null : i
      this.$emit('selected', {answer, 'save': this.checked !== null});
    }
  },
  name: "TestQuestions"
}
</script>

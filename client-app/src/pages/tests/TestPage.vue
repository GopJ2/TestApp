<template>
  <div class="h-100" v-if="questions.length > 0">
    <div v-for="question in questions" :key="question.id">
      <test-questions
          v-if="question.isActive"
          :questionText="question.questionText"
          :answers="question.answers"
          @selected="optionSelected"
      ></test-questions>
    </div>
    <div>
      <b-button v-if="!getStatusOfNextButton()" @click="getNextQuestion()">Next</b-button>
      <b-button v-else @click="goToResult()">Finish</b-button>
    </div>
  </div>
  <div v-else>
    <h2>There are no questions for you</h2>
  </div>
</template>

<script>
import api from "../../services/api";
import TestQuestions from "../../components/tests/TestQuestions";
export default {
  data() {
    return {
      questions: [],
      answersState: {},
    }
  },
  async created() {
    await this.loadOptionsForTest();
  },
  methods: {
    async loadOptionsForTest() {
      const testId = this.$route.params.id;
      const result = (await api.get(`TestQuestions/questions/${testId}`)).data;
      this.questions = result.map(el => Object.assign(el, {isActive: false}));
      this.questions[0].isActive = true;
    },
    getNextQuestion() {
      let index =  this.questions.findIndex(x => x.isActive);
      if (this.questions[index + 1]) {
        this.questions[index].isActive = false;
        this.questions[index + 1].isActive = true;
      }
    },
    getStatusOfNextButton() {
      let index =  this.questions.findIndex(x => x.isActive);
      return this.questions[index + 1] === undefined;
    },
    goToResult() {

    },
    optionSelected(option) {
      const {answer, save} = option;
      if (save) {
        this.answersState[answer.questionId] = answer.isCorrect;
        return;
      }

      delete this.answersState[answer.questionId];
    }
  },
  name: "TestPage",
  components: {
    TestQuestions
  },
}
</script>
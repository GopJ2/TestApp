<template>
  <div class="h-100">
    <div class="h-100 d-flex flex-column justify-content-center align-items-center" v-if="!checkAgreement()">
        <p class="my-4">Please accept the agreement</p>
        <router-link class="link-info page-link" to="/tests">Back to tests</router-link>
    </div>
    <div class="h-100 d-flex flex-column justify-content-center align-items-center" v-if="checkAgreement() && questions.length > 0">
      <div v-for="question in questions" :key="question.id">
        <test-questions
            v-if="question.isActive"
            :questionText="question.questionText"
            :answers="question.answers"
            @selected="optionSelected"
        ></test-questions>
      </div>
      <div>
        <b-button class="mt-3" v-if="!getStatusOfNextButton()" :disabled="nextDisabled" @click="getNextQuestion()">Next</b-button>
        <b-button class="mt-3" v-else :disabled="nextDisabled" @click="goToResult()">Finish</b-button>
      </div>
    </div>
  </div>
</template>

<script>
import api from "../../services/api";
import TestQuestions from "../../components/tests/TestQuestions";
import {mapActions, mapGetters} from 'vuex';
export default {
  data() {
    return {
      questions: [],
      answersState: {},
      nextDisabled: true,
    }
  },
  async created() {
    await this.loadOptionsForTest();
  },
  methods: {
    ...mapActions({
      setTestResult: 'testResult/setTestResult'
    }),
    async loadOptionsForTest() {
      const testId = this.$route.params.id;
      const result = (await api.get(`TestQuestions/questions/${testId}`)).data;
      this.questions = result.map(el => Object.assign(el, {isActive: false}));
      this.questions[0].isActive = true;
    },
    getNextQuestion() {
      let index =  this.questions.findIndex(x => x.isActive);
      if (index > -1 && this.questions[index + 1]) {
        this.nextDisabled = true;
        this.questions[index].isActive = false;
        this.questions[index + 1].isActive = true;
      }
    },
    getStatusOfNextButton() {
      let index =  this.questions.findIndex(x => x.isActive);
      return this.questions[index + 1] === undefined;
    },
    goToResult() {
        const testId = this.$route.params.id;
        const countOfCorrects = Object.values(this.answersState).filter(el => el).length;
        this.setTestResult({id: testId, questions: this.questions.length, correctAnswers: countOfCorrects });
        this.$router.push({path: `/results/${testId}`})
    },
    optionSelected(option) {
      const {answer, save} = option;
      if (save) {
        this.answersState[answer.questionId] = answer.isCorrect;
        this.nextDisabled = false;
        return;
      }
      this.nextDisabled = true;
      delete this.answersState[answer.questionId];
    },
    checkAgreement() {
      const result = this.getTest(this.$route.params.id);
      return result && result.agreementAccepted
    }
  },
  computed: {
    ...mapGetters({
      getTest: 'tests/test'
    })
  },
  name: "TestPage",
  components: {
    TestQuestions
  },
}
</script>
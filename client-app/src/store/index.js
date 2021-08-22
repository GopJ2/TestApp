import Vue from 'vue'
import Vuex from 'vuex'
import testResult from './modules/testResult';
import tests from "./modules/tests";
Vue.use(Vuex)

export default new Vuex.Store({
   modules: {
       testResult,
       tests
   }
});
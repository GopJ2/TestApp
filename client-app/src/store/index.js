import Vue from 'vue'
import Vuex from 'vuex'
import testResult from './modules/testResult';

Vue.use(Vuex)

export default new Vuex.Store({
   modules: {
       testResult
   }
});
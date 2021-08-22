import Vue from 'vue'
import VueRouter from 'vue-router'
import router from './router';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import App from "./App";
import store from './store';

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import './assets/styles/main.css'

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(VueRouter)

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')

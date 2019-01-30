import Vue from 'vue'
import App from './App.vue'

import "bootstrap/dist/css/bootstrap.min.css";
import store from "./store";

new Vue({
  el: '#app',
  render: h => h(App),
  store
})

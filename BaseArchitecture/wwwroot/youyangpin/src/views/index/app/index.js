import Vue from 'vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import Index from './index.vue'
require('../../../assets/css/reset.css');

Vue.use(ElementUI)
new Vue({
  render: h => h(Index)
}).$mount('#app')
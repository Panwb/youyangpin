import Vue from 'vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import Apply from './apply.vue'
require('../../../assets/css/reset.css');

Vue.use(ElementUI)
new Vue({
  render: h => h(Apply)
}).$mount('#app')
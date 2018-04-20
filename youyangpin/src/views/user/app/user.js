import Vue from 'vue'
import ElementUI from 'element-ui'
import '../../../../theme/index.css'
import User from './user.vue'
require('../../../assets/css/reset.css');
Vue.use(ElementUI)
new Vue({
  render: h => h(User)
}).$mount('#app')
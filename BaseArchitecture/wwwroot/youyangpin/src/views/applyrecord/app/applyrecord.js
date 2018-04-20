import Vue from 'vue'
import ElementUI from 'element-ui'
import '../../../../theme/index.css'
import '../../../assets/css/reset.css'
import User from './applyrecord.vue'

Vue.use(ElementUI)
new Vue({
  render: h => h(User)
}).$mount('#app')
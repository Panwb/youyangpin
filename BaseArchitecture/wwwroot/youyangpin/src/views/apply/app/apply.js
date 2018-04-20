import Vue from 'vue'
import ElementUI from 'element-ui'
import '../../../../theme/index.css'
import '../../../assets/css/reset.css'
import Apply from './apply.vue'

Vue.use(ElementUI)
new Vue({
  render: h => h(Apply)
}).$mount('#app')
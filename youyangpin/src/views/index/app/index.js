import Vue from 'vue'
import ElementUI from 'element-ui'
import '../../../../theme/index.css'
import '../../../assets/css/reset.css'
import Index from './index.vue'


Vue.use(ElementUI)
new Vue({
  render: h => h(Index)
}).$mount('#app')
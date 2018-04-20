import Vue from 'vue'
import ElementUI from 'element-ui'
<<<<<<< HEAD
import '../../../../theme/index.css'
import '../../../assets/css/reset.css'
import Apply from './apply.vue'
=======
import 'element-ui/lib/theme-chalk/index.css'
import Apply from './apply.vue'
require('../../../assets/css/reset.css');
>>>>>>> 344b0bc09fb9b6a239ba071944d6b75bd67d9743

Vue.use(ElementUI)
new Vue({
  render: h => h(Apply)
}).$mount('#app')
import Vue from 'vue'
import ElementUI from 'element-ui'
<<<<<<< HEAD
import '../../../../theme/index.css'
=======
import 'element-ui/lib/theme-chalk/index.css'
>>>>>>> 344b0bc09fb9b6a239ba071944d6b75bd67d9743
import User from './user.vue'
require('../../../assets/css/reset.css');
Vue.use(ElementUI)
new Vue({
  render: h => h(User)
}).$mount('#app')
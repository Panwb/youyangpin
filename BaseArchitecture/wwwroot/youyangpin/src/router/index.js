import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/page/Index'
import User from '@/page/User'
import Myorder from '@/page/Myorder'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Index',
      component: Index
    },
    {
      path: '/User',
      name: 'User',
      component: User
    }
  ]
})

import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './app.vue'
import routes from './routes'
import store from './vuex'
import actions from './vuex/actions'
import { sync } from 'vuex-router-sync'   
import Element from 'element-ui'
import Component from './components'  // 全局组件
import * as util from './util/common'
import '!style-loader!css-loader!less-loader!./assets/theme/index.css'
import '!style-loader!css-loader!less-loader!./assets/styles/css/reset.css'

Vue.use(VueRouter)
Vue.use(Component)
Vue.use(Element)
Vue.prototype.util = util

// 路由实例
const router = new VueRouter({
    mode: 'hash', // hash: 使用 URL hash 值来作路由。支持所有浏览器，包括不支持 HTML5 History Api 的浏览器。history: 依赖 HTML5 History API 和服务器配置。
    scrollBehavior(to, from, savePosition) {   // 前进或后退,滚动到原来的位置
        if (savePosition) {
            return savePosition
        } else {
            return {
                x: 0,
                y: 0
            }
        }
    },
    routes: [
        ...routes
    ],
})

sync(store,router)

router.beforeEach((to, from, next) => {
    sessionStorage.setItem('prePath',from.path);
    if (to.matched.some(record => record.meta.auth)) {
        // let userInfo = JSON.parse(localStorage.getItem('user'));
        console.log(util.isAuthTimeout() ? '需要登录' : '不需要登录')
        if (util.isAuthTimeout()) {
            next({
                path: '/login',
                query: {
                    redirect: to.path
                }
            })
        }
        else {
            if (to.fullPath == '/') {
                next('/index')
            }
            else {
                next()
            }
        }
    }
    else {
        if (to.fullPath == '/') {
            next('/index')
        }
        else {
            next()
        }
    }
})

new Vue({
    store,
    router,
    render: h => h(App)
}).$mount('#app')



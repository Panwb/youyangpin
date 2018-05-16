const Apply = () => import ('views/apply/apply.vue');
const Applyrecord = () => import ('views/applyrecord/applyrecord.vue');
const Forgetpwd = () => import ('views/forgetpwd/forgetpwd.vue');
const Freight = () => import ('views/freight/freight.vue');
const Index = () => import ('views/index/index.vue');
const Login = () => import ('views/login/login.vue'); // 登录
const Modifypwd = () => import ('views/modifypwd/modifypwd.vue');
const Order = () => import ('views/order/order.vue');
const Register = () => import ('views/register/register.vue');
const User = () => import ('views/user/user.vue');
export default [{
    path: '/apply',
    name: '申请拿样',
    component: Apply,
    meta: {
        auth: false,
    },
}, {
    path: '/applyrecord',
    name: '申请记录',
    component: Applyrecord,
    meta: {
        auth: true,
    },
}, {
    path: '/forgetpwd',
    name: '忘记密码',
    component: Forgetpwd,
    meta: {
        auth: false,
    },
}, {
    path: '/freight',
    name: '运费申请',
    component: Freight,
    meta: {
        auth: true,
    },
}, {
    path: '/index',
    name: '首页',
    component: Index,
    meta: {
        auth: false,
    },
}, {
    path: '/login',
    name: '登录',
    component: Login,
    meta: {
        auth: false,
    },
}, {
    path: '/modifypwd',
    name: '修改密码',
    component: Modifypwd,
    meta: {
        auth: true,
    },
}, {
    path: '/order',
    name: '我的订单',
    component: Order,
    meta: {
        auth: true,
    },
}, {
    path: '/register',
    name: '注册',
    component: Register,
    meta: {
        auth: false,
    },
}, {
    path: '/user',
    name: '个人信息',
    component: User,
    meta: {
        auth: true,
    },
}];
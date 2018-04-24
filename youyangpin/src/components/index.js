import footer from './footer.vue'
import header from './header.vue'

const install = function (Vue) {
    Vue.component(header.name, header)
    Vue.component(footer.name, footer)
}

export default install
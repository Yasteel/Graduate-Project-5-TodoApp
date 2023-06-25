import { createApp } from 'vue/dist/vue.esm-bundler'
import Home from './components/Home.vue'

createApp()
    .component('Home', Home)
    .mount('#app')
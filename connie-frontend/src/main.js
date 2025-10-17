import './assets/main.css'
import './assets/css/global.css'
import './assets/css/home.css'
import './assets/css/news.css'
import './assets/css/services.css'
import './assets/css/teachers.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

createApp(App).use(router).mount('#app')

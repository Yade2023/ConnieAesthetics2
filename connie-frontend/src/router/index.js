import { createRouter, createWebHistory } from 'vue-router';
import Home from '../components/Home.vue';
import News from '../components/News.vue';
import Services from '../components/Services.vue';
import Teachers from '../components/Teachers.vue';

const routes = [
  { path: '/', component: Home },
  { path: '/news', component: News },
  { path: '/services', component: Services },
  { path: '/teachers', component: Teachers },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router; 
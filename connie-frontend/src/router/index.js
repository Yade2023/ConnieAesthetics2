import { createRouter, createWebHistory, createWebHashHistory } from 'vue-router';
import Home from '../views/homeViews.vue';
import News from '../components/News.vue';
import Services from '../views/servicesViews.vue';
import Teachers from '../views/teachersViews.vue';

// 檢查是否在 GitHub Pages 環境中
const isGitHubPages = window.location.hostname.includes('github.io') || 
                     window.location.pathname.includes('/ConnieAesthetics2/');

const router = createRouter({
  // 在 GitHub Pages 中使用 hash 模式，其他環境使用 history 模式
  history: isGitHubPages ? createWebHashHistory(import.meta.env.BASE_URL) : createWebHistory(import.meta.env.BASE_URL),
  routes : [
  { path: '/', component: Home },
  // { path: '/news', component: News },
  { path: '/services', component: Services },
  { path: '/teachersViews', component: Teachers },
],
  
});

export default router; 
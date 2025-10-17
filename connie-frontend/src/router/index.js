import { createRouter, createWebHistory, createWebHashHistory } from 'vue-router';
import Home from '../components/Home.vue';
import News from '../components/News.vue';
import Services from '../components/Services.vue';
import Teachers from '../components/Teachers.vue';

// 檢查是否在 GitHub Pages 環境中
const isGitHubPages = window.location.hostname.includes('github.io') || 
                     window.location.pathname.includes('/ConnieAesthetics2/');

const router = createRouter({
  // 在 GitHub Pages 中使用 hash 模式，其他環境使用 history 模式
  history: isGitHubPages ? createWebHashHistory(import.meta.env.BASE_URL) : createWebHistory(import.meta.env.BASE_URL),
  routes : [
  { path: '/', component: Home },
  { path: '/news', component: News },
  { path: '/services', component: Services },
  { path: '/teachers', component: Teachers },
],
  
});

export default router; 
<template>
    <!-- 單層導航欄 - 所有元素在同一行 -->
    <nav class="navbar" role="navigation" aria-label="主要導航">
      <div class="navbar-content">
        <!-- 左側：Logo 和品牌名稱 -->
        <router-link to="/" class="logo-link" aria-label="康妮泌乳美學首頁">
          <img :src="connieLogo" alt="康妮泌乳美學 Logo" class="main-logo" loading="eager" width="40" height="40" />
          <span class="brand">康妮泌乳美學</span>
        </router-link>
        
        <!-- 中間：導航連結 -->
        <div class="nav-menu" role="menubar">
          <!-- <router-link to="/news" role="menuitem" aria-label="最新消息">最新消息</router-link> -->
          <router-link to="/teachersViews" role="menuitem" aria-label="老師介紹">老師介紹</router-link>
          <router-link to="/services" role="menuitem" aria-label="服務項目">服務項目</router-link>
        </div>
        
        <!-- 右側：聯絡按鈕和社群媒體圖示 -->
        <div class="navbar-actions">
          <a href="#" class="contact-btn" @click.prevent="openContactModal">連絡我們／預約諮詢</a>
          <a href="https://www.instagram.com/connie_cares_spa/" target="_blank" class="social-btn" aria-label="Instagram">
            <img :src="igLogo" alt="Instagram" loading="lazy" width="22" height="22" />
          </a>
          <a href="https://www.facebook.com/conniecares1990" target="_blank" class="social-btn" aria-label="Facebook">
            <img :src="fbLogo" alt="Facebook" loading="lazy" width="22" height="22" />
          </a>
        </div>
      </div>
    </nav>

</template>

<script setup>
import '../assets/css/navber.css';
import connieLogo from '../../public/logo/logoConnie.png';
import igLogo from '../../public/logo/logoIg.png';
import fbLogo from '../../public/iconn/FB.ico';
//通知其他元件開啟彈窗
const openContactModal = () => {
  console.log('觸發聯絡模態框'); // 除錯用
  const event = new CustomEvent('openContactModal', {
    detail: { service: '' }
  });
  window.dispatchEvent(event);
};

// import '../assets/js/navber.js'
// import '../assets/json/navber.json'
</script>

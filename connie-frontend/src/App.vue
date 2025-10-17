<script setup>
import Footer from './components/Footer.vue';
import { ref, onMounted, onUnmounted } from 'vue';
import ContactModal from './components/ContactModal.vue';

const showModal = ref(false);
const selectedService = ref('');

const handleOpenContactModal = (event) => {
  selectedService.value = event.detail?.service || '';
  showModal.value = true;
};

const handleKeydown = (event) => {
  // ESC 鍵關閉模態框
  if (event.key === 'Escape' && showModal.value) {
    showModal.value = false;
  }
};

onMounted(() => {
  window.addEventListener('openContactModal', handleOpenContactModal);
  document.addEventListener('keydown', handleKeydown);
});

onUnmounted(() => {
  window.removeEventListener('openContactModal', handleOpenContactModal);
  document.removeEventListener('keydown', handleKeydown);
});
</script>

<template>
  <div id="app">
    <!-- 單層導航欄 - 所有元素在同一行 -->
    <nav class="navbar" role="navigation" aria-label="主要導航">
      <div class="navbar-content">
        <!-- 左側：Logo 和品牌名稱 -->
        <router-link to="/" class="logo-link" aria-label="康妮泌乳美學首頁">
          <img src="../public/LOGO.png" alt="康妮泌乳美學 Logo" class="main-logo" loading="eager" width="40" height="40" />
          <span class="brand">康妮泌乳美學</span>
        </router-link>
        
        <!-- 中間：導航連結 -->
        <div class="nav-menu" role="menubar">
          <router-link to="/news" role="menuitem" aria-label="最新消息">最新消息</router-link>
          <router-link to="/teachers" role="menuitem" aria-label="老師介紹">老師介紹</router-link>
          <router-link to="/services" role="menuitem" aria-label="服務項目">服務項目</router-link>
        </div>
        
        <!-- 右側：聯絡按鈕和社群媒體圖示 -->
        <div class="navbar-actions">
          <a href="#" class="contact-btn" @click.prevent="showModal = true">連絡我們／預約諮詢</a>
          <a href="https://www.instagram.com/connie_cares_spa/" target="_blank" class="social-btn" aria-label="Instagram">
            <img src="../public/IG.png" alt="Instagram" loading="lazy" width="22" height="22" />
          </a>
          <a href="https://www.facebook.com/conniecares1990" target="_blank" class="social-btn" aria-label="Facebook">
            <img src="../public/FB.ico" alt="Facebook" loading="lazy" width="22" height="22" />
          </a>
        </div>
      </div>
    </nav>

    <main class="main-content" role="main">
      <router-view />
    </main>
    <ContactModal :show="showModal" :selected-service="selectedService" @close="showModal = false" />
    <Footer />
  </div>
</template>

<style scoped>
#app {
  font-family: 'Noto Sans TC', Arial, sans-serif;
  background: #f7faf9;
  min-height: 100vh;
}
/* 單層導航欄 - 淺粉色背景 */
.navbar {
  background: #ffabce;
  padding: 0.5rem 0;
  box-shadow: 0 2px 8px rgba(233,174,188,0.06);
  display: flex;
  justify-content: space-between;
  position: sticky;
  top: 0;
  z-index: 100;
}

.navbar-content {
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 2rem;
  border-color:solid rgb(0, 0, 0);
}

.navbar-actions {
  display: flex;
  align-items: center;
  gap: 1.5rem;
}

.social-btn {
  background: white;
  border-radius: 50%;
  padding: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.social-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(0,0,0,0.15);
}

.social-btn img {
  width: 22px;
  height: 22px;
  object-fit: contain;
}

.contact-btn {
  background: #f8e1e7;
  color: #6c757d;
  border: none;
  border-radius: 20px;
  padding: 0.5rem 1rem;
  font-weight: 600;
  text-decoration: none;
  transition: all 0.3s ease;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
  margin-right: 1rem;
}

.contact-btn:hover {
  background: #f3f3f3;
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(0,0,0,0.15);
}
.logo-link {
  display: flex;
  align-items: center;
  text-decoration: none;
  margin-right: 160px;
}
.main-logo {
  height: 40px;
  width: 40px;
  object-fit: contain;
  border-radius: 50%;
  background: #fff;
  margin-right: 10px;
}
.brand {
  font-size: 1.5rem;
  color: #103b3c;
  font-weight: bold;
  letter-spacing: 2px;
}

.nav-menu {
  display: flex;
  gap: 1rem;
  margin-right: 20px;
}

.nav-menu a {
  color: #103b3c;
  font-size: 1.1rem;
  text-decoration: none;
  border-radius: 8px;
  padding: 0.5rem 1rem;
  transition: background 0.3s, color 0.3s;
  font-weight: 500;
}

.nav-menu a.router-link-exact-active, .nav-menu a:hover {
  background: linear-gradient(90deg, #f8e1e7 0%, #f3f3f3 100%);
  color: #d16d8a;
}
.main-content {
  max-width: 1600px;
  margin: 2rem auto 0 auto;
  background: #fff;
  border-radius: 16px;
  box-shadow: 0 2px 16px rgba(233,174,188,0.06);
  padding: 2rem 2.5rem;
}
@media (max-width: 991px) {
  .navbar-content {
    padding: 0 1rem;
    flex-direction: column;
    align-items: flex-start;
    gap: 1rem;
  }
  
  .nav-menu {
    width: 100%;
    justify-content: center;
    flex-wrap: wrap;
  }
  
  .navbar-actions {
    width: 100%;
    margin-left: 60px;

    justify-content: center;
  }
  
  .main-content { 
    padding: 1rem; 
    margin-top: 1rem;
  }
}

@media (max-width: 768px) {
  .navbar-actions {
    gap: 0.3rem;
  }
  
  .social-btn {
    padding: 0.4rem;
  }
  
  .contact-btn {
    padding: 0.4rem 0.8rem;
    font-size: 0.9rem;
  }
  
  .nav-menu {
    gap: 1.5rem;
  }
  
  .nav-menu a {
    font-size: 1rem;
    padding: 0.4rem 0.8rem;
  }
}
.site-footer {
  width: 100%;
  background: #f8f3f6;
  color: #b97a95;
  text-align: center;
  padding: 18px 0 10px 0;
  font-size: 1.1rem;
  position: relative;
  bottom: 0;
  left: 0;
  border-top: 1px solid #f0e0e7;
  margin-top: 16px;
}


</style>

<template>
  <div id="app">
    <navber />
    <main class="main-content" role="main">
      <router-view />
    </main>
    <ContactModal :show="showModal" :selected-service="selectedService" @close="showModal = false" />

    <Footer />
  </div>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from 'vue';
import navber from './components/navber.vue';
import Footer from './components/Footer.vue';
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


<style scoped>
#app {
  font-family: 'Noto Sans TC', Arial, sans-serif;
  background: #f7faf9;
  min-height: 100vh;
}

.main-content {
  max-width: 1400px;
  margin: 2rem auto 0 auto;
  background: #f8f3f6;
  border-radius: 16px;
  box-shadow: 0 2px 16px rgba(233, 174, 188, 0.06);
  padding: 1.5rem 2.5rem 0rem 2.5rem;
}

@media (max-width: 991px) {
  .main-content {
    padding: 1rem;
    margin-top: 1rem;
  }
}

@media (max-width: 768px) {
  .main-content {
    margin-top: 0.5rem;
    padding: 1rem 0.8rem;
  }
}

@media (max-width: 480px) {
  .main-content {
    padding: 0.8rem 0.5rem;
    margin-top: 0.3rem;
  }
}
</style>

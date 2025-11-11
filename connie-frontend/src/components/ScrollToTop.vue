<template>
  <transition name="fade">
    <button
      v-if="isVisible"
      @click="scrollToTop"
      class="scroll-to-top-btn"
      aria-label="回到頂部"
      title="回到頂部"
    >
      <img 
        src="/img/人形圖.png" 
        alt="回到頂部" 
        class="scroll-icon"
      />
    </button>
    
  </transition>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from 'vue';

const isVisible = ref(false);

// 檢查滾動位置
const checkScrollPosition = () => {
  // 當滾動超過 300px 時顯示按鈕
  isVisible.value = window.pageYOffset > 300;
};

// 平滑滾動到頂部
const scrollToTop = () => {
  window.scrollTo({
    top: 0,
    behavior: 'smooth'
  });
};

// 節流函數，避免頻繁觸發
const throttle = (func, delay) => {
  let timeoutId;
  let lastExecTime = 0;
  return function (...args) {
    const currentTime = Date.now();
    
    if (currentTime - lastExecTime > delay) {
      func.apply(this, args);
      lastExecTime = currentTime;
    } else {
      clearTimeout(timeoutId);
      timeoutId = setTimeout(() => {
        func.apply(this, args);
        lastExecTime = Date.now();
      }, delay - (currentTime - lastExecTime));
    }
  };
};

const throttledCheckScroll = throttle(checkScrollPosition, 100);

onMounted(() => {
  window.addEventListener('scroll', throttledCheckScroll);
});

onUnmounted(() => {
  window.removeEventListener('scroll', throttledCheckScroll);
});
</script>

<style scoped>
.scroll-to-top-btn {
  position: fixed;
  bottom: 30px;
  right: 30px;
  width: 60px;
  height: 60px;
  background: rgba(255, 255, 255, 0.95);
  border: 2px solid #e9aebc;
  border-radius: 50%;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  box-shadow: 0 4px 12px rgba(233, 174, 188, 0.3);
  z-index: 1000;
  transition: all 0.3s ease;
  backdrop-filter: blur(10px);
}

.scroll-to-top-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(233, 174, 188, 0.4);
  background: rgba(255, 255, 255, 1);
}

.scroll-to-top-btn:active {
  transform: translateY(0);
}

.scroll-icon {
  width: 36px;
  height: 36px;
  object-fit: contain;
  filter: drop-shadow(0 1px 2px rgba(0, 0, 0, 0.1));
}

.scroll-to-top-btn:hover .scroll-icon {
  transform: scale(1.1);
  transition: transform 0.2s ease;
}

/* 淡入淡出動畫 */
.fade-enter-active,
.fade-leave-active {
  transition: all 0.3s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
  transform: translateY(20px);
}

/* 響應式設計 */
@media (max-width: 768px) {
  .scroll-to-top-btn {
    bottom: 20px;
    right: 20px;
    width: 50px;
    height: 50px;
  }
  
  .scroll-icon {
    width: 30px;
    height: 30px;
  }
}

@media (max-width: 480px) {
  .scroll-to-top-btn {
    bottom: 15px;
    right: 15px;
    width: 45px;
    height: 45px;
  }
  
  .scroll-icon {
    width: 28px;
    height: 28px;
  }
}
</style>
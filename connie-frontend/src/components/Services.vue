<template>
  <div class="services-page">
    <div class="page-header">
      <h1>服務項目</h1>
      <p class="page-subtitle">專業的泌乳美學服務，為每位媽媽提供最貼心的照護</p>
    </div>
    
    <div v-if="loading" class="loading-container">
      <div class="loading-spinner"></div>
      <p>載入中...</p>
    </div>
    
    <div v-else-if="error" class="error-container">
      <p>載入服務資訊時發生錯誤，請稍後再試</p>
      <button @click="loadServices" class="retry-button">重新載入</button>
    </div>
    
    <div v-else class="services-grid">
      <div 
        v-for="(item, index) in services" 
        :key="item.Id" 
        class="service-card"
        :style="{ animationDelay: `${index * 0.1}s` }"
      >
        <div class="service-icon">
          <span>{{ item.Icon }}</span>
        </div>
        <div class="service-content">
          <h3 class="service-title">{{ item.Name }}</h3>
          <p class="service-description">{{ item.Description }}</p>
          <div class="service-details">
            <div class="service-price">{{ item.Price }}</div>
            <div class="service-duration">{{ item.Duration }}</div>
          </div>
        </div>
        <div class="service-actions">
          <button class="inquiry-button" @click="openInquiry(item.Name)">
            立即諮詢
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';

const services = ref([]);
const loading = ref(false);
const error = ref(false);

// 靜態服務數據
const staticServices = [
  {
    Id: 1,
    Icon: "🤱",
    Name: "泌乳諮詢",
    Description: "專業泌乳顧問提供一對一諮詢服務，協助媽媽解決哺乳過程中的各種問題",
    Price: "NT$ 1,500/次",
    Duration: "60分鐘"
  },
  {
    Id: 2,
    Icon: "💆‍♀️",
    Name: "胸部按摩",
    Description: "專業胸部按摩服務，促進血液循環，緩解胸部不適，提升哺乳品質",
    Price: "NT$ 2,000/次",
    Duration: "90分鐘"
  },
  {
    Id: 3,
    Icon: "🌿",
    Name: "草本護理",
    Description: "使用天然草本成分進行胸部護理，溫和滋潤，適合敏感肌膚",
    Price: "NT$ 1,800/次",
    Duration: "75分鐘"
  },
  {
    Id: 4,
    Icon: "🧘‍♀️",
    Name: "放鬆療程",
    Description: "結合按摩與放鬆技巧，幫助媽媽減壓，提升整體身心健康",
    Price: "NT$ 2,500/次",
    Duration: "120分鐘"
  },
  {
    Id: 5,
    Icon: "📚",
    Name: "育兒指導",
    Description: "提供專業育兒知識指導，包括哺乳技巧、嬰兒照護等實用資訊",
    Price: "NT$ 1,200/次",
    Duration: "45分鐘"
  },
  {
    Id: 6,
    Icon: "💝",
    Name: "產後恢復",
    Description: "針對產後媽媽的專業恢復服務，幫助身體快速回到最佳狀態",
    Price: "NT$ 3,000/次",
    Duration: "150分鐘"
  }
];

const loadServices = () => {
  loading.value = true;
  error.value = false;
  
  // 模擬載入時間
  setTimeout(() => {
    services.value = staticServices;
    loading.value = false;
  }, 500);
};

const openInquiry = (serviceName) => {
  // 觸發聯絡我們模態框，並傳遞服務名稱
  const event = new CustomEvent('openContactModal', { 
    detail: { service: serviceName } 
  });
  window.dispatchEvent(event);
};

onMounted(() => {
  loadServices();
});
</script>

<style scoped>
.services-page {
  padding: 2rem 0;
}

.page-header {
  text-align: center;
  margin-bottom: 3rem;
}

.page-header h1 {
  font-size: 2.5rem;
  color: #103b3c;
  margin-bottom: 1rem;
  font-weight: 700;
}

.page-subtitle {
  font-size: 1.2rem;
  color: #6c757d;
  max-width: 600px;
  margin: 0 auto;
  line-height: 1.6;
}

.loading-container, .error-container {
  text-align: center;
  padding: 3rem;
}

.loading-spinner {
  width: 40px;
  height: 40px;
  border: 4px solid #f3f3f3;
  border-top: 4px solid #e9aebc;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  margin: 0 auto 1rem;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.retry-button {
  background: #e9aebc;
  color: white;
  border: none;
  padding: 0.8rem 1.5rem;
  border-radius: 25px;
  cursor: pointer;
  font-weight: 600;
  transition: background 0.3s;
}

.retry-button:hover {
  background: #d16d8a;
}

.services-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(350px, 1fr));
  gap: 2rem;
  max-width: 1200px;
  margin: 0 auto;
}

.service-card {
  background: white;
  border-radius: 16px;
  padding: 2rem;
  box-shadow: 0 4px 20px rgba(233, 174, 188, 0.1);
  transition: all 0.3s ease;
  animation: fadeInUp 0.6s ease forwards;
  opacity: 0;
  transform: translateY(20px);
  display: flex;
  flex-direction: column;
  height: 100%;
}

@keyframes fadeInUp {
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

.service-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 8px 30px rgba(233, 174, 188, 0.15);
}

.service-icon {
  font-size: 3rem;
  text-align: center;
  margin-bottom: 1.5rem;
}

.service-content {
  flex: 1;
  text-align: center;
  margin-bottom: 1.5rem;
}

.service-title {
  font-size: 1.5rem;
  color: #103b3c;
  margin-bottom: 1rem;
  font-weight: 600;
}

.service-description {
  color: #6c757d;
  line-height: 1.6;
  font-size: 1rem;
  margin-bottom: 1rem;
}

.service-details {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
  padding: 0.8rem;
  background: #f8f9fa;
  border-radius: 8px;
  font-size: 0.9rem;
}

.service-price {
  color: #e9aebc;
  font-weight: 600;
}

.service-duration {
  color: #6c757d;
  font-weight: 500;
}

.service-actions {
  text-align: center;
}

.inquiry-button {
  background: linear-gradient(135deg, #e9aebc 0%, #d16d8a 100%);
  color: white;
  border: none;
  padding: 0.8rem 2rem;
  border-radius: 25px;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  box-shadow: 0 4px 15px rgba(233, 174, 188, 0.3);
}

.inquiry-button:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(233, 174, 188, 0.4);
}

@media (max-width: 768px) {
  .services-grid {
    grid-template-columns: 1fr;
    gap: 1.5rem;
  }
  
  .service-card {
    padding: 1.5rem;
  }
  
  .page-header h1 {
    font-size: 2rem;
  }
  
  .page-subtitle {
    font-size: 1rem;
  }
}
</style> 
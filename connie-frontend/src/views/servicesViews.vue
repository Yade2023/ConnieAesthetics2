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
      <div v-for="(item, index) in services" :key="item.Id" class="service-card"
        :style="{ animationDelay: `${index * 0.1}s` }">
        <div class="service-icon">
          <img 
            :src="item.Icon" 
            :alt="item.Name" 
            @error="handleImageError"
            @load="handleImageLoad"
          />
        </div>
        <div class="service-content">
          <h3 class="service-title">{{ item.Name }}</h3>
          <p class="service-description">{{ item.Description }}</p>
          <div class="service-details">
            <div class="service-price">{{ item.Price }}</div>
            <div class="service-duration">{{ item.Duration }}</div>
          </div>
          <div class="service-details">
            <div class="service-price">{{ item.Price2 }}</div>
            <div class="service-duration">{{ item.Duration2 }}</div>
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

// 獲取正確的基礎路徑
const getImagePath = (imageName) => {
  const base = import.meta.env.BASE_URL || '/';
  return `${base}img/${imageName}`;
};

// 靜態服務數據
const staticServices = [
  {
    Id: 1,
    Icon: getImagePath("產後駝背調理.png"),
    Name: "產後駝背調理",
    Description: "現在還在駝背的妳不論是曾經工作姿勢不良累積還是育兒的姿勢導致，產後修護是給自己一次重生的機會選擇專業產康老師，邁向自信的開始💜🩵💙",
    Price: "NT$2000",
    Price2: "NT$3000",
    Duration: "80分鐘",
    Duration2: "120分鐘"
  },
  {
    Id: 2,
    Icon: getImagePath("ConnieCares.png"),
    Name: "胸部按摩",
    Description: "專業胸部按摩服務，促進血液循環，緩解胸部不適，提升哺乳品質",
    Price: "NT$ 2,000/次",
    Duration: "90分鐘"
  },
  {
    Id: 3,
    Icon: getImagePath("LOGO.png"),
    Name: "草本護理",
    Description: "使用天然草本成分進行胸部護理，溫和滋潤，適合敏感肌膚",
    Price: "NT$ 1,800/次",
    Duration: "75分鐘"
  },
  {
    Id: 4,
    Icon: getImagePath("ConnieCares.png"),
    Name: "放鬆療程",
    Description: "結合按摩與放鬆技巧，幫助媽媽減壓，提升整體身心健康",
    Price: "NT$ 2,500/次",
    Duration: "120分鐘"
  },
  {
    Id: 5,
    Icon: getImagePath("LOGO.png"),
    Name: "育兒指導",
    Description: "提供專業育兒知識指導，包括哺乳技巧、嬰兒照護等實用資訊",
    Price: "NT$ 1,200/次",
    Duration: "45分鐘"
  },
  {
    Id: 6,
    Icon: getImagePath("ConnieCares.png"),
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

const handleImageError = (event) => {
  console.error('圖片載入失敗:', event.target.src);
  // 設置備用圖片或隱藏圖片
  event.target.style.display = 'none';
};

const handleImageLoad = (event) => {
  console.log('圖片載入成功:', event.target.src);
};

onMounted(() => {
  loadServices();
});
</script>


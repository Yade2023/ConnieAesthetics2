<template>
  <div class="services-page">
    <div v-if="loading" class="loading-container">
      <div class="loading-spinner"></div>
      <p>載入中...</p>
    </div>

    <div v-else class="services-container">
      <!-- 遍歷所有服務分類 -->
      <div v-for="(services, category) in servicesData" :key="category" class="service-category">
        <h2 class="category-title">{{ category }}</h2>
        <div class="services-grid">
          <ProductCard
            v-for="(service, index) in services"
            :key="`${category}-${index}`"
            :image="getServiceImage(category, service.課程名稱)"
            :name="service.課程名稱"
            :time="service.時間"
          />
        </div>
      </div>
    </div>
  </div>
</template>
---------------------------------------

<script setup>
import { ref, onMounted } from 'vue';
import '../assets/css/services.css';
import ProductCard from '@/components/card.vue';
import servicesJson from '../assets/json/服務項目.json';

// 響應式數據
const loading = ref(true);
const servicesData = ref({});

// 根據分類和服務名稱獲取對應的圖片
const getServiceImage = (category, serviceName) => {
  // 根據具體服務名稱映射到對應的圖片 - 使用更豐富的圖片分配
  const serviceImageMap = {
    // 孕期課程 - 使用孕期資料夾的所有圖片
    '孕婦按摩': '/img/孕期/孕婦按摩.png',
    '孕期乳肩舒緩按摩': '/img/孕期/孕期乳肩舒緩按摩.png',
    '產前乳腺保養': '/img/孕期/產前乳腺保養.jpg',
    
    // 產後課程 - 分配不同的產後圖片
    '子宮按摩': '/img/產後/產後子宮按摩.png',
    '泌乳疏通按摩': '/img/產後/什麼時候需要泌乳師.jpg',
    '產後按摩': '/img/產後/產後按摩.png',
    '臀腿按摩': '/img/產後/臀腿按摩.jpg',
    '美式骨盆調理': '/img/產後/美式骨盆調理.png',
    '腹直肌復位調理': '/img/產後/產後子宮按摩適合時機.png',
    '紮肚技術費/次': '/img/產後/產後子宮按摩到院服務.png',
    
    // 放鬆課程
    '女性艾草溫罐': '/img/放鬆/艾草溫冠.jpg',
    '女性按摩': '/img/放鬆/駝背紓壓調理.png',
    '美胸按摩': '/img/放鬆/美胸按摩.png',
    '美胸假體按摩': '/img/放鬆/美胸按摩.png',
    '女性私密處除毛': '/img/放鬆/駝背紓壓調理.png',
    
    // 攜伴可約
    '男性艾草溫罐': '/img/放鬆/艾草溫冠.jpg',
    '男性按摩': '/img/放鬆/駝背紓壓調理.png',
    '男性私密處除毛': '/img/放鬆/駝背紓壓調理.png'
  };

  // 根據服務名稱獲取對應圖片，如果沒有就使用預設圖片
  const imagePath = serviceImageMap[serviceName] || '/img/康妮老師介紹.jpg';
  
  // 調試信息
  console.log(`分類: ${category}, 服務: ${serviceName}, 圖片路徑: ${imagePath}`);
  console.log(`BASE_URL: ${import.meta.env.BASE_URL}`);
  
  return imagePath;
};

// 載入服務數據
onMounted(() => {
  try {
    servicesData.value = servicesJson;
    loading.value = false;
  } catch (error) {
    console.error('載入服務數據失敗:', error);
    loading.value = false;
  }
});
</script>


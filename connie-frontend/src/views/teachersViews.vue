<template>
  <div class="teachers-page">
    <!-- <h1>老師介紹</h1> -->
    <div class="image-container" id="zoom">
      <img :src="connieTeacher" alt="康妮老師介紹" class="teacher-image">
    </div>
    <!-- <ul>
      <li v-for="item in teachers" :key="item.Id">
        <strong>{{ item.name }}</strong>（{{ item.title }}）：{{ item.description }}
      </li>
    </ul> -->
  </div>
</template>

<script setup>
import '../assets/css/teachers.css';
import connieTeacher from '../../public/img/康妮老師介紹.jpg';
import { onMounted, onUnmounted } from 'vue';
import createZoomEffect from '../assets/js/zoomEffect.js';

// Zoom 效果實例
let zoomEffectInstance = null;

// 響應式縮放參數
const getResponsiveZoomSettings = () => {
  const width = window.innerWidth;
  
  if (width >= 1200) {
    // 大型桌面
    return { maxScale: 1.10, speed: 0.0008 };
  } else if (width >= 992) {
    // 中型桌面/筆電
    return { maxScale: 1.08, speed: 0.0008 };
  } else if (width >= 768) {
    // 平板橫向
    return { maxScale: 1.06, speed: 0.0006 };
  } else if (width >= 576) {
    // 平板直向
    return { maxScale: 1.05, speed: 0.0005 };
  } else {
    // 手機
    return { maxScale: 1.04, speed: 0.0004 };
  }
};

// 生命週期處理
onMounted(() => {
  const zoomSettings = getResponsiveZoomSettings();
  
  // 模擬 jQuery cycle 的參數設定
  zoomEffectInstance = createZoomEffect('zoom', {
    fx: 'zoom',           // 效果類型
    sync: false,          // 非同步
    delay: 2000,          // 延遲2秒開始
    minScale: 1,          // 最小縮放比例
    maxScale: zoomSettings.maxScale,  // 響應式最大縮放比例
    speed: zoomSettings.speed,        // 響應式縮放速度
    fps: 60               // 幀率
  });
  
  // 視窗大小改變時重新啟動效果
  const handleResize = () => {
    if (zoomEffectInstance) {
      zoomEffectInstance.stop();
      
      // 延遲重啟以避免頻繁切換，增加防抖時間
      setTimeout(() => {
        const newSettings = getResponsiveZoomSettings();
        zoomEffectInstance = createZoomEffect('zoom', {
          fx: 'zoom',
          sync: false,
          delay: 0, // 立即開始，不需要再延遲
          minScale: 1,
          maxScale: newSettings.maxScale,
          speed: newSettings.speed,
          fps: 60
        });
      }, 500); // 增加到 500ms 防抖時間
    }
  };
  
  // 防抖函數
  let resizeTimeout;
  const debouncedHandleResize = () => {
    clearTimeout(resizeTimeout);
    resizeTimeout = setTimeout(handleResize, 200); // 200ms 防抖
  };
  
  // 監聽視窗大小變化
  window.addEventListener('resize', debouncedHandleResize);
  
  // 清理函數
  onUnmounted(() => {
    window.removeEventListener('resize', debouncedHandleResize);
    clearTimeout(resizeTimeout); // 清理防抖計時器
    if (zoomEffectInstance) {
      zoomEffectInstance.stop();
    }
  });
});

onUnmounted(() => {
  if (zoomEffectInstance) {
    zoomEffectInstance.stop();
  }
});

// 靜態老師數據
// const staticTeachers = [
//   {
//     Id: 1,
//     name: "康妮老師",
//     title: "資深泌乳顧問",
//     description: "擁有10年泌乳諮詢經驗，國際認證泌乳顧問(IBCLC)，專精於解決各種哺乳難題，幫助無數媽媽成功哺乳。"
//   },
//   {
//     Id: 2,
//     name: "小美老師",
//     title: "專業按摩師",
//     description: "專業按摩師執照，專精於產後胸部按摩與護理，溫柔細心的服務深受媽媽們喜愛。"
//   },
//   {
//     Id: 3,
//     name: "雅婷老師",
//     title: "育兒指導專家",
//     description: "兒童發展學碩士，擁有豐富的育兒指導經驗，提供專業的嬰兒照護與育兒知識指導。"
//   }
// ];

// onMounted(() => {
//   teachers.value = staticTeachers;
// });
</script> 
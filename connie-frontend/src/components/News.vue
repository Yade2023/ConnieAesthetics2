<template>
    <div class="news-container">
      <div class="social-widgets-container">
        <!-- Facebook Page Plugin -->
        <div class="fb-page" 
          data-href="https://www.facebook.com/conniecares1990"
          data-tabs="timeline,events,messages"
          data-width="500"
          data-height="700"
          data-small-header="false"
          data-adapt-container-width="true"
          data-hide-cover="false"
          data-show-facepile="true">
           <!--FACEBOOK連結-->
          <blockquote cite="https://www.facebook.com/conniecares1990" class="fb-xfbml-parse-ignore">  
            <a href="https://www.facebook.com/conniecares1990">康妮泌乳美學</a>
          </blockquote>
        </div>
      </div>
    </div>
</template>

<script setup>
import { onMounted, computed } from 'vue';
import '../assets/css/news.css';

// 處理圖片路徑，確保在 GitHub Pages 上正確顯示
const igIconUrl = computed(() => {
  // 在開發環境使用相對路徑，在生產環境使用絕對路徑
  if (import.meta.env.DEV) {
    return '/IG.png';
  } else {
    // 在 GitHub Pages 上使用正確的 base URL
    return import.meta.env.BASE_URL + 'IG.png';
  }
});

onMounted(() => {
  // 載入Facebook SDK
  loadFacebookSDK();
  // 調整widget寬度
  adjustWidgetWidth();
  // 監聽視窗大小變化
  window.addEventListener('resize', adjustWidgetWidth);
});

const loadFacebookSDK = () => {
  // 檢查是否已經載入過Facebook SDK
  if (window.FB) {
    window.FB.XFBML.parse();
    return;
  }

  // 創建Facebook SDK腳本
  const script = document.createElement('script');
  script.src = 'https://connect.facebook.net/zh_TW/sdk.js#xfbml=1&version=v18.0';
  script.async = true;
  script.defer = true;
  script.crossOrigin = 'anonymous';
  
  document.head.appendChild(script);
};


const adjustWidgetWidth = () => {
  const fbPage = document.querySelector('.fb-page');
  if (fbPage) {
    const containerWidth = fbPage.parentElement.offsetWidth;
    const windowWidth = window.innerWidth;
    
    // if (windowWidth <= 480) {
    //   // 小手機
    //   fbPage.setAttribute('data-width', Math.min(containerWidth - 20, 300));
    //   fbPage.setAttribute('data-height', '500');
    // } else if (windowWidth <= 768) {
    //   // 平板和大手機
    //   fbPage.setAttribute('data-width', Math.min(containerWidth - 40, 400));
    //   fbPage.setAttribute('data-height', '600');
    // } else if (windowWidth <= 900) {
    //   // 小桌面
    //   fbPage.setAttribute('data-width', Math.min(containerWidth - 20, 450));
    //   fbPage.setAttribute('data-height', '700');
    // } else {
    //   // 大桌面
    //   fbPage.setAttribute('data-width', '500');
    //   fbPage.setAttribute('data-height', '700');
    // }
    
    // 重新解析Facebook widget
    if (window.FB) {
      window.FB.XFBML.parse();
    }
  }
};
</script> 
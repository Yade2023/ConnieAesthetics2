<template>
  <div class="news-page">
    <h1>最新消息</h1>
    <div class="social-widgets-container">
      <!-- Facebook Page Plugin -->
      <div class="fb-page" 
        data-href="https://www.facebook.com/conniecares1990"
        data-tabs="timeline"
        data-width="400"
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
      <!--IG連結-->
      <div class="ig-widget-container">
        <iframe src="//lightwidget.com/widgets/dac98d3517105b29a9bd4ea57cae3703.html" scrolling="no" allowtransparency="true" class="lightwidget-widget" style="width:100%;border:0;overflow:hidden;"></iframe>
      </div>
    </div>
  </div>
</template>

<script setup>
import { onMounted } from 'vue';

onMounted(() => {
  // 載入Facebook SDK
  loadFacebookSDK();
  // 載入LightWidget
  loadLightWidget();
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

const loadLightWidget = () => {
  if (document.querySelector('script[src*="lightwidget.js"]')) return;
  const script = document.createElement('script');
  script.src = 'https://cdn.lightwidget.com/widgets/lightwidget.js';
  script.async = true;
  document.head.appendChild(script);
};
</script>

<style scoped>
.news-page {
  padding: 20px;
  max-width: 1200px;
  margin: 0 auto;
}

.news-page h1 {
  text-align: center;
  color: #333;
  margin-bottom: 30px;
  font-size: 2.5rem;
}

.social-widgets-container {
  display: flex;
  justify-content: center;
  align-items: flex-start;
  min-height: 700px;
  max-width: 900px;
  margin: 0 auto;
  width: 100%;
}

.fb-page {
  width: 100% !important;
  min-width: 300px;
  max-width: 800px;
}

/* 響應式設計 */
@media (max-width: 900px) {
  .social-widgets-container {
    max-width: 100vw;
  }
  .fb-page {
    max-width: 100vw;
    min-width: 0;
  }
}
@media (max-width: 768px) {
  .news-page {
    padding: 10px;
  }
  .news-page h1 {
    font-size: 2rem;
  }
  .social-widgets-container {
    min-height: 600px;
    padding: 0 2vw;
  }
  .fb-page {
    data-width: 100% !important;
    max-width: 100vw;
  }
}
</style> 
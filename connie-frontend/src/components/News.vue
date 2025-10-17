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
        <div class="ig-showcase">
          <div class="ig-header">
            <img :src="igIconUrl" alt="Instagram" class="ig-icon" />
            <h3>追蹤我們的 Instagram</h3>
          </div>
          <div class="ig-content">
            <p class="ig-description">最新動態與照片分享</p>
            <div class="ig-features">
              <div class="ig-feature">
                <span class="feature-icon">📸</span>
                <span>專業照片</span>
              </div>
              <div class="ig-feature">
                <span class="feature-icon">💡</span>
                <span>專業知識</span>
              </div>
              <div class="ig-feature">
                <span class="feature-icon">❤️</span>
                <span>客戶見證</span>
              </div>
            </div>
            <a href="https://www.instagram.com/connie_cares_spa/" target="_blank" class="ig-link-btn">
              <img :src="igIconUrl" alt="Instagram" width="24" height="24" />
              前往 Instagram 追蹤
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { onMounted, computed } from 'vue';

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
    if (window.innerWidth <= 900) {
      fbPage.setAttribute('data-width', Math.min(containerWidth - 20, 400));
    } else {
      fbPage.setAttribute('data-width', 400);
    }
    // 重新解析Facebook widget
    if (window.FB) {
      window.FB.XFBML.parse();
    }
  }
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
  gap: 2.5rem;
}

.fb-page {
  width: 400px !important;
  min-width: 300px;
  max-width: 400px;
}

.ig-widget-container {
  width: 400px;
  min-width: 300px;
  max-width: 400px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.ig-showcase {
  width: 100%;
  background: linear-gradient(135deg, #f8e1e7 0%, #ffffff 50%, #f3f3f3 100%);
  border-radius: 16px;
  padding: 2rem;
  box-shadow: 0 8px 32px rgba(233, 174, 188, 0.15);
  border: 1px solid rgba(233, 174, 188, 0.2);
  min-height: 400px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  text-align: center;
}

.ig-header {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 0.8rem;
  margin-bottom: 1.5rem;
}

.ig-icon {
  width: 32px;
  height: 32px;
  filter: drop-shadow(0 2px 4px rgba(0,0,0,0.1));
}

.ig-header h3 {
  color: #d16d8a;
  font-size: 1.4rem;
  font-weight: 600;
  margin: 0;
}

.ig-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 1.5rem;
}

.ig-description {
  color: #6c757d;
  font-size: 1rem;
  margin: 0;
  line-height: 1.5;
}

.ig-features {
  display: flex;
  flex-direction: column;
  gap: 0.8rem;
  width: 100%;
}

.ig-feature {
  display: flex;
  align-items: center;
  gap: 0.8rem;
  padding: 0.6rem 1rem;
  background: rgba(255, 255, 255, 0.7);
  border-radius: 12px;
  border: 1px solid rgba(233, 174, 188, 0.1);
  transition: all 0.3s ease;
}

.ig-feature:hover {
  background: rgba(255, 255, 255, 0.9);
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(233, 174, 188, 0.2);
}

.feature-icon {
  font-size: 1.2rem;
  width: 24px;
  text-align: center;
}

.ig-feature span:last-child {
  color: #333;
  font-weight: 500;
  font-size: 0.95rem;
}

/* 響應式設計 */
@media (max-width: 900px) {
  .social-widgets-container {
    max-width: 100vw;
    gap: 0.5rem;
    flex-direction: column;
    align-items: center;
  }
  .fb-page, .ig-widget-container {
    max-width: 100vw;
    width: 100% !important;
    min-width: 0;
  }
}
@media (max-width: 768px) {
  .news-page {
    padding: 10px;
  }
  .news-page h1 {
    font-size: 2rem;
    margin-bottom: 20px;
  }
  .social-widgets-container {
    min-height: 600px;
    padding: 0 2vw;
    gap: 1rem;
  }
  .ig-showcase {
    min-height: 350px;
    padding: 1.5rem;
  }
  .ig-features {
    gap: 0.6rem;
  }
  .ig-feature {
    padding: 0.5rem 0.8rem;
  }
}

@media (max-width: 480px) {
  .news-page {
    padding: 8px;
  }
  .news-page h1 {
    font-size: 1.8rem;
    margin-bottom: 15px;
  }
  .social-widgets-container {
    min-height: 500px;
    padding: 0 1vw;
    gap: 0.5rem;
  }
  .ig-showcase {
    min-height: 300px;
    padding: 1rem;
  }
  .ig-header h3 {
    font-size: 1.2rem;
  }
  .ig-description {
    font-size: 0.9rem;
  }
  .ig-feature span:last-child {
    font-size: 0.85rem;
  }
}

.ig-link-btn {
  display: inline-flex;
  align-items: center;
  gap: 0.5rem;
  background: linear-gradient(45deg, #E4405F, #C13584);
  color: white;
  text-decoration: none;
  padding: 0.8rem 1.5rem;
  border-radius: 25px;
  font-weight: 600;
  transition: all 0.3s ease;
  box-shadow: 0 4px 15px rgba(196, 53, 132, 0.3);
}

.ig-link-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(196, 53, 132, 0.4);
  color: white;
}

.ig-link-btn img {
  width: 24px;
  height: 24px;
  filter: brightness(0) invert(1);
}
</style> 
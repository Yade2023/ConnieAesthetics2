<script setup>
import { computed } from 'vue'

const props = defineProps({

  image: { type: String, required: true },

  name: { type: String, required: true },

  time: { type: String, default: '' },

  colors: { type: Array, default: () => [] },

  originalPrice: { type: [String, Number], default: '' },

  salePrice: { type: [String, Number], default: '' }
})

const imageSrc = computed(() => {
  const url = props.image

  // 如果是完整的 URL (http/https)，直接使用
  if (/^https?:\/\//.test(url)) {
    console.log(`使用完整URL: ${url}`)
    return url
  }

  // 如果是以 / 開頭的絕對路徑，需要加上基礎路徑
  if (url.startsWith('/')) {
    const baseUrl = import.meta.env.BASE_URL || '/'
    // 如果 baseUrl 已經以 / 結尾，避免重複
    const cleanBaseUrl = baseUrl.endsWith('/') ? baseUrl.slice(0, -1) : baseUrl
    const finalUrl = `${cleanBaseUrl}${url}`
    console.log(`處理絕對路徑: 原始=${url}, 基礎路徑=${baseUrl}, 最終=${finalUrl}`)
    return finalUrl
  }

  // 相對路徑使用 import.meta.url 解析
  const resolvedUrl = new URL(url, import.meta.url).href
  console.log(`處理相對路徑: 原始=${url}, 解析後=${resolvedUrl}`)
  return resolvedUrl
})

// 圖片錯誤處理
const handleImageError = (event) => {
  console.error('圖片載入失敗:', event.target.src)
  console.error('原始圖片路徑:', props.image)
}

// 圖片載入成功處理
const handleImageLoad = (event) => {
  console.log('圖片載入成功:', event.target.src)
}
</script>

<template>
  <div class="product-card">
    <div class="image-wrapper">
      <img :src="imageSrc" :alt="`${name}服務圖片`" class="product-image" @error="handleImageError"
        @load="handleImageLoad" />
      <!-- 顯示圖片路徑以便調試 -->
      <div class="debug-info"
        style="position: absolute; bottom: 0; left: 0; background: rgba(0,0,0,0.7); color: white; font-size: 10px; padding: 2px;">
        康妮泌乳美學
      </div>
    </div>
    <div class="content-wrapper">
      <h3 class="service-name">{{ name }}</h3>
      <div class="service-time" v-if="time">
        <span class="time-label">時間：</span>
        <span class="time-value">{{ time }}</span>
      </div>
    </div>
  </div>
</template>

<style scoped>
.product-card {
  display: flex;
  flex-direction: column;
  height: 300px; /* 固定總高度 */
  background-color: #fff;
  border-radius: 0.75rem;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s ease, box-shadow 0.2s ease;
  cursor: pointer;
  overflow: hidden;
}

/* Hover effect: lift the card slightly and deepen the shadow. */
.product-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
}

/* 圖片區域 - 占70%高度 */
.image-wrapper {
  position: relative;
  width: 100%;
  height: 70%; /* 7:3比例的70% */
  overflow: hidden;
  border-radius: 0.75rem 0.75rem 0 0;
  background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%); /* 漸層背景 */
}

/* Actual product image filling the wrapper. */
.product-image {
  width: 100%;
  height: 100%;
  object-fit: contain; /* 保持圖片比例，完整顯示不裁切 */
  object-position: center; /* 圖片居中顯示 */
  background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%); /* 漸層背景填充空白區域 */
  display: block;
  border-radius: 0.75rem 0.75rem 0 0; /* 圓角與容器一致 */
}

/* 內容區域 - 占30%高度 */
.content-wrapper {
  height: 30%; /* 7:3比例的30% */
  padding: 1rem;
  display: flex;
  flex-direction: column;
  justify-content: center;
  background: #fff;
}

/* 服務名稱樣式 */
.service-name {
  margin: 5px 0px;
  font-size: 1.1rem;
  font-weight: 700;
  color: #103b3c;
  line-height: 1.3;
  margin-bottom: 0.5rem;
  text-align: center;
}

/* Color swatches row. */
.colors {
  display: flex;
  gap: 0.3rem;
}

/* Individual color swatch.  Provides a subtle border to separate
   similar colours and maintains a consistent size. */
.color-dot {
  width: 0.75rem;
  height: 0.75rem;
  border-radius: 0.125rem;
  border: 1px solid rgba(0, 0, 0, 0.1);
  flex: 0 0 0.75rem;
}

/* Product name styling.  Uses a heavier weight to stand out but
   remains relatively restrained so longer names wrap gracefully. */
.name {
  margin: 0;
  font-size: 0.95rem;
  font-weight: 600;
  color: #333;
  line-height: 1.3;
}

/* Service time styling */
.service-time {
  display: flex;
  align-items: center;
  justify-content: center;
  padding-top: 5px;
  gap: 0.2rem;
}

.time-label {
  font-size: 0.85rem;
  color: #666;
  font-weight: 500;
}

.time-value {
  font-size: 0.9rem;
  color: #d16d8a;
  font-weight: 700;
  background: linear-gradient(135deg, rgba(233, 174, 188, 0.15), rgba(209, 109, 138, 0.15));
  padding: 0.2rem 0.8rem;
  border-radius: 20px;
  border: 1px solid rgba(209, 109, 138, 0.2);
}

/* 響應式設計 */
@media (max-width: 768px) {
  .product-card {
    height: 280px; /* 手機版稍微降低高度 */
  }
  
  .service-name {
    font-size: 1rem;
  }
  
  .content-wrapper {
    padding: 0.8rem;
  }
  
  .time-value {
    font-size: 0.8rem;
    padding: 0.15rem 0.6rem;
  }
}
</style>

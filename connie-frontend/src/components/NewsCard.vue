<!-- src/components/NewsCard.vue -->
<script setup>
import { computed } from 'vue'

const props = defineProps({
  imageUrl: { type: String, required: true },
  title: { type: String, required: true },           // 大標（覆蓋在圖上）
  subtitle: { type: String, default: '' },           // 小標（覆蓋在圖上）
  source: { type: String, default: '' },             // 右下角「圖片來源」
  tag: { type: String, default: '' },                // 左下角小圓點標籤：例如「中山・北松山 立法委員」
  body: { type: String, default: '' },               // 下方摘要
  maxLines: { type: Number, default: 3 },            // 摘要最多顯示行數
  rounded: { type: String, default: '1rem' },        // 卡片圓角
})

const emits = defineEmits(['read-more', 'click'])
const bodyStyle = computed(() => ({
  WebkitLineClamp: String(props.maxLines)
}))
</script>

<template>
  <article class="news-card" :style="{ '--radius': rounded }" @click="$emit('click')">
    <!-- 圖片區 -->
    <div class="cover">
      <img :src="imageUrl" alt="" />
      <div class="shade"></div>

      <!-- 左下角文字（大標/小標/標籤） -->
      <div class="cover-text">
        <div v-if="subtitle" class="subtitle">{{ subtitle }}</div>
        <h3 class="title">{{ title }}</h3>
        <div v-if="tag" class="tag">
          <span class="dot"></span>{{ tag }}
        </div>
      </div>

      <!-- 右下角來源 -->
      <div v-if="source" class="source">圖片來源：{{ source }}</div>
    </div>

    <!-- 內容區 -->
    <div class="body">
      <p class="excerpt" :style="bodyStyle">{{ body }}</p>
      <button v-if="body && body.length > 0" class="more" type="button"
              @click.stop="$emit('read-more')">顯示更多</button>
    </div>
  </article>
</template>

<style scoped>
.news-card{
  display: grid;
  gap: .5rem;
  background: #111;
  color: #eee;
  border-radius: var(--radius, 1rem);
  overflow: hidden;
  box-shadow: 0 6px 20px rgba(0,0,0,.25);
  cursor: pointer;
}

.cover{
  position: relative;
  aspect-ratio: 16/9;
  overflow: hidden;
  isolation: isolate;                /* 讓遮罩分層 */
}
.cover img{
  width: 100%;
  height: 100%;
  object-fit: cover;
  display:block;
  transform: scale(1.02);
}

/* 底部漸層黑遮罩 */
.shade{
  position:absolute; inset:0;
  background:
    linear-gradient(180deg, rgba(0,0,0,0) 40%, rgba(0,0,0,.85) 100%);
  z-index: 1;
}

/* 覆蓋在圖上的文字 */
.cover-text{
  position:absolute; left:1rem; right:1rem; bottom: .8rem;
  z-index: 2;
  display:grid; gap:.25rem;
}
.subtitle{
  font-size:.85rem; color:#b5c7ff; opacity:.9; font-weight:600;
  text-shadow: 0 1px 2px rgba(0,0,0,.6);
}
.title{
  margin:0;
  font-size: clamp(1.1rem, 2.2vw, 1.6rem);
  font-weight: 800; line-height:1.1;
  color: #ffd86b;                         /* 黃色大標 */
  letter-spacing: .5px;
  text-shadow: 0 2px 4px rgba(0,0,0,.8);
}
.tag{
  margin-top:.15rem;
  font-size:.8rem; color:#cfd6ff; opacity:.95;
  display:flex; align-items:center; gap:.4rem;
}
.tag .dot{
  width:.5rem; height:.5rem; border-radius:50%;
  background:#4da3ff; display:inline-block; flex:0 0 .5rem;
  box-shadow: 0 0 0 2px rgba(77,163,255,.25);
}

/* 右下角來源文字 */
.source{
  position:absolute; right:.8rem; bottom:.6rem; z-index: 2;
  font-size:.75rem; color:#d0d0d0; opacity:.9;
  text-shadow: 0 1px 2px rgba(0,0,0,.7);
}

/* 下方內文 */
.body{ padding: .25rem .9rem 1rem; }
.excerpt{
  margin:.25rem 0 .5rem;
  color:#eaeaea; opacity:.95;
  line-height:1.55;
  display:-webkit-box; -webkit-box-orient:vertical; overflow:hidden;
  /* 行數限制由 props 控制 */
}
.more{
  background: transparent; border: none; color:#84b6ff;
  font-weight:600; padding:0; cursor:pointer;
}
.more:hover{ text-decoration: underline; }
</style>

<!-- 
    使用方式
<template>
  <NewsCard
    image-url="/images/img/ConnieImg/ConniePriceList.jpg"
    subtitle="4G吃到飽恐遭聯合下架"
    title="聯合蠶斷下架"
    tag="中山・北松山 立法委員"
    source="資料彙整"
    :max-lines="3"
    :rounded="'1rem'"
    :body="content"
    @read-more="onReadMore"
    @click="onOpenDetail"
  />
</template>

<script setup>
import NewsCard from '@/components/NewsCard.vue'
const content = '遠傳與台灣大哥大從本月開始，全面停售經銷通路4G吃到飽資費方案...'
const onReadMore = () => { /* 打開全文/導頁 */ }
const onOpenDetail = () => { /* 卡片整張點擊 */ }
</script>

-->
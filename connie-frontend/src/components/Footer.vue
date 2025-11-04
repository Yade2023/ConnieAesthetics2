<template>
  <footer class="site-footer">
    <!-- 同業連結區塊 -->
    <div class="partner-links">
      <h4 class="partner-title">合作夥伴</h4>
      <div class="partner-logos">
        <a v-for="partner in partners" :key="partner.id" :href="partner.link"
          :target="partner.link ? '_blank' : '_self'" class="partner-logo" :class="{ 'no-link': !partner.link }"
          @click="handlePartnerClick(partner)">
          <img :src="partner.logo" :alt="partner.name" :title="partner.name" />
          <span class="partner-name">{{ partner.name }}</span>
        </a>
      </div>
    </div>

    <!-- 原有的footer內容 -->
    <div>
      <div class="footer-content">
        <a class="footer-link" href="/" target="_self">© 2025 康妮泌乳美學.版權所有</a>
        <span class="footer-divider">|</span>
        <span class="footer-counter">瀏覽人次：{{ viewCount }}</span>
      </div>
      <div>
        <span class="footer-keywords">康妮泌乳美學/桃園泌乳/新北泌乳/孕婦按摩/產後修護/桃園新北紮肚/腹直肌復位紮肚/到府泌乳師/到府產康師 </span>
      </div>
    </div>
  </footer>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import '../assets/css/footer.css';
import youyiLogo from '/img/logo攸羿美學.jpg';
import rebirthLogo from '/img/logo芮貝斯美學.jpg';
import lakeLogo from '/img/logo萊可美學.jpg';
import mumin from '/img/logo沐敏生活美學.jpg';
import goodPregnancy from '/img/logo幸孕媽咪spa.jpg';
import warmJar from '/img/logo溫罐好好.jpg';
const viewCount = ref(0);

// 合作夥伴資料
const partners = ref([
  {
    id: 1,
    name: '攸羿美學',
    logo: youyiLogo,
    link: 'https://www.facebook.com/youyimeixue' // 您可以在這裡添加連結，如果沒有連結就留空
  },
  {
    id: 2,
    name: '芮貝斯美學',
    logo: rebirthLogo,
    link: 'https://www.facebook.com/rebirth.bueaty' // 您可以在這裡添加連結
  },
  {
    id: 3,
    name: '萊可美學',
    logo: lakeLogo,
    link: 'https://www.facebook.com/profile.php?id=61574402562558&sk=reviews' // 您可以在這裡添加連結
  },
    {
    id: 4,
    name: '沐敏生活美學',
    logo: mumin,
    link: 'https://www.facebook.com/profile.php?id=61553281288567' // 您可以在這裡添加連結，如果沒有連結就留空
  },
  {
    id: 5,
    name: '幸孕媽咪spa',
    logo: goodPregnancy,
    link: 'https://www.facebook.com/profile.php?id=100082801132301' // 您可以在這裡添加連結
  },
  {
    id: 6,
    name: '溫罐好好',
    logo: warmJar,
    link: 'https://www.facebook.com/profile.php?id=100078423794304' // 您可以在這裡添加連結
  }
]);

// 處理合作夥伴點擊事件
const handlePartnerClick = (partner) => {
  if (!partner.link) {
    // 如果沒有連結，可以顯示一個提示或執行其他動作
    console.log(`點擊了 ${partner.name}，但尚未設定連結`);
    // 可以在這裡添加模態框顯示更多資訊或聯絡方式
  }
};

onMounted(() => {
  // 計數器只在本機顯示（可用密碼或特定條件顯示）
  // 這裡先用localStorage模擬
  let count = localStorage.getItem('connie-visit-count');
  if (!count) count = 0;
  count = parseInt(count) + 1;
  localStorage.setItem('connie-visit-count', count);
  viewCount.value = count;
});
</script>

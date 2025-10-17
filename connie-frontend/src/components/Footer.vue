<template>
  <footer class="site-footer">
    <div class="footer-content">
      <a class="footer-link" href="/" target="_self">© 2025  康妮泌乳美學.版權所有</a>
      <span class="footer-divider">|</span>
      <span class="footer-counter">瀏覽人次：{{ viewCount }}</span>
    </div>
    <div>
      <span class="footer-keywords">康妮泌乳美學/桃園泌乳/新北泌乳/孕婦按摩/產後修護/桃園新北紮肚/腹直肌復位紮肚/到府泌乳師/到府產康師 </span>
    </div>
  </footer>
</template>

<style>
.footer-keywords {
  font-size: 8px;

}
</style>
<script setup>
import { ref, onMounted } from 'vue';

const viewCount = ref(0);

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


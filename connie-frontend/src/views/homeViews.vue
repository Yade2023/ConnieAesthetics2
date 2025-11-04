<template>
    <div class="home-page">
        <section class="hero-section" ref="heroSection">
            <div class="hero-bg" ref="heroBg"></div>
            <div class="hero-middle-layer" ref="heroMiddleLayer"></div>
            <div class="hero-content" ref="heroContent">
                <h1 class="hero-title">康妮泌乳美學</h1>
                <p class="hero-subtitle">專業的媽媽哺乳、身體護理與美學服務，陪伴每一位媽媽健康美麗。</p>
                <div class="hero-actions">
                    <router-link to="/services" class="cta-button primary">了解服務</router-link>
                    <a href="#newsFB" @click="scrollToNews" class="cta-button secondary">最新消息</a>
                </div>
            </div>
        </section>

        <section id="newsFB" class="news-section">
            <h2>最新消息</h2>
            <div class="container">
                <news />
            </div>
        </section>

    </div>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from 'vue';
import News from '@/components/News.vue';
import '../assets/css/home.css';

const heroSection = ref(null);
const heroBg = ref(null);
const heroMiddleLayer = ref(null);
const heroContent = ref(null);

let ticking = false;
let isMobile = false;

// 檢測是否為移動設備
const checkMobile = () => {
    isMobile = window.innerWidth <= 768;
};

// 平滑滾動到 News 區域
const scrollToNews = (event) => {
    event.preventDefault(); // 阻止默認錨點跳轉

    const newsSection = document.getElementById('newsFB');
    if (newsSection) {
        // 計算滾動位置（考慮導航欄高度）
        const navbarHeight = 80; // 導航欄高度，根據實際調整
        const targetPosition = newsSection.offsetTop - navbarHeight;

        // 平滑滾動
        window.scrollTo({
            top: targetPosition,
            behavior: 'smooth'
        });

        // 添加一個簡單的動畫提示
        setTimeout(() => {
            newsSection.style.transform = 'scale(1.02)';
            newsSection.style.transition = 'transform 0.3s ease';
            setTimeout(() => {
                newsSection.style.transform = 'scale(1)';
            }, 300);
        }, 500);
    }
};

const handleScroll = () => {
    if (ticking || !heroSection.value || !heroBg.value || !heroMiddleLayer.value || !heroContent.value) return;

    // 使用 requestAnimationFrame 優化性能
    requestAnimationFrame(() => {
        const scrolled = window.pageYOffset;
        const section = heroSection.value;
        const sectionTop = section.offsetTop;
        const sectionHeight = section.offsetHeight;
        const windowHeight = window.innerHeight;

        // 只在 hero section 可見範圍內執行視差效果
        if (scrolled >= sectionTop - windowHeight && scrolled <= sectionTop + sectionHeight) {

            // 在移動設備上減少視差效果以提升性能
            if (!isMobile) {
                // 背景視差效果 - 桌面版（增強效果）
                const bgRate = (scrolled - sectionTop) * 0.8; // 增加從 0.3 到 0.8
                const bgScale = 1.1 + (scrolled - sectionTop) / sectionHeight * 0.2; // 動態縮放
                heroBg.value.style.transform = `translate3d(0, ${bgRate}px, 0) scale(${bgScale})`;

                // 中間層視差效果 - 不同速度
                const middleRate = (scrolled - sectionTop) * 0.5;
                const middleRotate = (scrolled - sectionTop) / sectionHeight * 360 * 0.2;
                heroMiddleLayer.value.style.transform = `translate3d(0, ${-middleRate}px, 0) rotate(${middleRotate}deg) scale(${1 + (scrolled - sectionTop) / sectionHeight * 0.5})`;

                // 內容視差效果 - 桌面版（增強效果）
                const contentRate = (scrolled - sectionTop) * 0.4; // 增加從 0.15 到 0.4
                const opacity = Math.max(0.1, 1 - (scrolled - sectionTop) / (sectionHeight * 0.6)); // 更快淡出
                const contentScale = 1 - (scrolled - sectionTop) / sectionHeight * 0.3; // 內容縮放效果

                heroContent.value.style.transform = `translate3d(0, ${contentRate}px, 0) scale(${Math.max(0.7, contentScale)})`;
                heroContent.value.style.opacity = opacity;
            } else {
                // 移動設備上簡化效果
                const opacity = Math.max(0.3, 1 - (scrolled - sectionTop) / (sectionHeight * 0.7));
                const mobileContentRate = (scrolled - sectionTop) * 0.2; // 移動設備也加點視差
                heroContent.value.style.opacity = opacity;
                heroContent.value.style.transform = `translate3d(0, ${mobileContentRate}px, 0)`;

                // 移動設備背景稍微移動
                const mobileBgRate = (scrolled - sectionTop) * 0.1;
                heroBg.value.style.transform = `translate3d(0, ${mobileBgRate}px, 0)`;

                // 移動設備中間層效果
                const mobileMiddleRate = (scrolled - sectionTop) * 0.15;
                heroMiddleLayer.value.style.transform = `translate3d(0, ${-mobileMiddleRate}px, 0)`;
            }
        } else if (scrolled > sectionTop + sectionHeight) {
            // 當完全滾動過 hero section 時重置
            heroContent.value.style.opacity = '0.1';
            heroContent.value.style.transform = 'translate3d(0, 0, 0) scale(0.7)';
            if (!isMobile) {
                heroBg.value.style.transform = `translate3d(0, ${sectionHeight * 0.8}px, 0) scale(1.3)`;
            } else {
                heroBg.value.style.transform = `translate3d(0, ${sectionHeight * 0.1}px, 0)`;
            }
        } else {
            // 重置到初始狀態
            heroContent.value.style.opacity = '1';
            heroContent.value.style.transform = 'translate3d(0, 0, 0) scale(1)';
            heroBg.value.style.transform = isMobile ? 'translate3d(0, 0, 0)' : 'translate3d(0, 0, 0) scale(1.1)';
        }

        ticking = false;
    });

    ticking = true;
};

// 節流的 resize 處理
let resizeTimeout;
const handleResize = () => {
    if (resizeTimeout) clearTimeout(resizeTimeout);
    resizeTimeout = setTimeout(() => {
        checkMobile();
        // 在尺寸變化時重置效果
        if (heroContent.value && heroBg.value && heroMiddleLayer.value) {
            heroContent.value.style.transform = 'translate3d(0, 0, 0) scale(1)';
            heroContent.value.style.opacity = '1';
            heroBg.value.style.transform = isMobile ? 'translate3d(0, 0, 0)' : 'translate3d(0, 0, 0) scale(1.1)';
            heroMiddleLayer.value.style.transform = 'translate3d(0, 0, 0)';
        }
    }, 250);
};

onMounted(() => {
    checkMobile();
    window.addEventListener('scroll', handleScroll, { passive: true });
    window.addEventListener('resize', handleResize, { passive: true });

    // 初始化效果
    if (heroContent.value && heroBg.value && heroMiddleLayer.value) {
        heroContent.value.style.opacity = '1';
        heroContent.value.style.transform = 'translate3d(0, 0, 0) scale(1)';
        heroBg.value.style.transform = isMobile ? 'translate3d(0, 0, 0)' : 'translate3d(0, 0, 0) scale(1.1)';
        heroMiddleLayer.value.style.transform = 'translate3d(0, 0, 0)';
    }
});

onUnmounted(() => {
    window.removeEventListener('scroll', handleScroll);
    window.removeEventListener('resize', handleResize);
    if (resizeTimeout) clearTimeout(resizeTimeout);
});
</script>

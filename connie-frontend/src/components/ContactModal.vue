<template>
  <div v-if="show" class="modal-overlay" @click.self="close" role="dialog" aria-modal="true"
    aria-labelledby="modal-title">
    <div class="modal-content" @click="stopPropagation" role="document">
      <div class="modal-header">
        <h2 id="modal-title">聯絡我們</h2>
        <p v-if="selectedService" class="service-note">
          您正在諮詢：<strong>{{ selectedService }}</strong>
        </p>
        <p v-else class="welcome-note">歡迎與我們聯繫，我們將為您提供專業的服務</p>
      </div>

      <div class="contact-methods">
        <div class="contact-method">
          <div class="method-icon">📱</div>
          <h3>Line 諮詢</h3>
          <p>掃描 QR Code 加入我們的 Line</p>
          <img src="../../public/img/ConnieLineQRCode.jpg" alt="Line QR Code" class="qrcode-img" />
        </div>

        <div class="contact-method">
          <div class="method-icon">📍</div>
          <h3>地址位置</h3>
          <p>338桃園市蘆竹區大竹北路15巷6號3樓</p>
          <div class="map-container">
            <iframe
              src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d903.7852174767253!2d121.252832!3d25.029293!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x346821fe1ee8a903%3A0xf9c724e24c8278fa!2z5bq35aau576O5a24L-WtleWppuaMieaRqS_nlKLlvozmjInmkakv6auU5oWL6Kq_55CG!5e0!3m2!1szh-TW!2stw!4v1762227319827!5m2!1szh-TW!2stw"
              width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"
              referrerpolicy="no-referrer-when-downgrade"></iframe>
          </div>
        </div>

      </div>

      <button class="close-btn" @click="close" aria-label="關閉對話框">關閉</button>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  show: Boolean,
  selectedService: String
});

const emit = defineEmits(['close']);

const close = () => {
  console.log('關閉模態框'); // 除錯用
  emit('close');
};

// 防止事件冒泡
const stopPropagation = (event) => {
  event.stopPropagation();
};
</script>

<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 9999;
  padding: 1rem;
}

.modal-content {
  background: white;
  border-radius: 16px;
  padding: 2rem;
  box-shadow: 0 8px 32px rgba(0, 0, 0, 0.15);
  max-width: 600px;
  width: 100%;
  max-height: 90vh;
  overflow-y: auto;
}

.modal-header {
  text-align: center;
  margin-bottom: 2rem;
}

.modal-header h2 {
  color: #103b3c;
  font-size: 2rem;
  margin-bottom: 1rem;
  font-weight: 700;
}

.service-note {
  background: #f8e1e7;
  color: #d16d8a;
  padding: 0.8rem 1.2rem;
  border-radius: 8px;
  font-weight: 600;
  margin-bottom: 1rem;
}

.welcome-note {
  color: #6c757d;
  font-size: 1.1rem;
  line-height: 1.6;
}

.contact-methods {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  gap: 1.5rem;
  margin-bottom: 2rem;
}

.contact-method {
  text-align: center;
  padding: 0.5rem;
  background: #f8f9fa;
  border-radius: 12px;
  transition: transform 0.3s ease;
}

.contact-method:hover {
  transform: translateY(-2px);
}

.method-icon {
  font-size: 1.8rem;
  margin-bottom: 0.5rem;
}

.contact-method h3 {
  color: #103b3c;
  font-size: 1.2rem;
  margin-bottom: 0.5rem;
  font-weight: 600;
}

.contact-method p {
  color: #6c757d;
  font-size: 0.9rem;
  margin-bottom: 1rem;
  line-height: 1.4;
}

.qrcode-img {
  max-width: 150px;
  max-height: 150px;
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}

.map-container {
  margin-top: 1rem;
  border-radius: 8px;
  overflow: hidden;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}

.phone-link,
.email-link {
  color: #e9aebc;
  text-decoration: none;
  font-weight: 600;
  font-size: 1.1rem;
  transition: color 0.3s;
}

.phone-link:hover,
.email-link:hover {
  color: #d16d8a;
}

.close-btn {
  background: linear-gradient(135deg, #e9aebc 0%, #d16d8a 100%);
  color: white;
  border: none;
  border-radius: 25px;
  padding: 0.8rem 2rem;
  font-size: 1.1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  display: block;
  margin: 0 auto;
  box-shadow: 0 4px 15px rgba(233, 174, 188, 0.3);
}

.close-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(233, 174, 188, 0.4);
}

@media (max-width: 768px) {
  .modal-content {
    padding: 1.5rem;
    margin: 1rem;
  }

  .contact-methods {
    gap: 1rem;
  }

  .modal-header h2 {
    font-size: 1.5rem;
  }
}
</style>
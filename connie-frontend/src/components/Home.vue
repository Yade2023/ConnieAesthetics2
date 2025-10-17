<template>
  <div class="home-page">
    <section class="hero-section">
      <div class="hero-content">
        <h1 class="hero-title">康妮泌乳美學</h1>
        <p class="hero-subtitle">專業的媽媽哺乳、身體護理與美學服務，陪伴每一位媽媽健康美麗。</p>
        <div class="hero-actions">
          <router-link to="/services" class="cta-button primary">了解服務</router-link>
          <router-link to="/news" class="cta-button secondary">最新消息</router-link>
        </div>
      </div>
    </section>
    
    <section class="features-section">
      <div class="features-grid">
        <div class="feature-card">
          <div class="feature-icon">🤱</div>
          <h3>泌乳諮詢</h3>
          <p>專業泌乳顧問協助媽媽順利哺乳，解決哺乳過程中的各種問題</p>
        </div>
        <div class="feature-card">
          <div class="feature-icon">💆‍♀️</div>
          <h3>產後護理</h3>
          <p>產後媽媽專屬身體調理與放鬆，幫助恢復身心健康</p>
        </div>
        <div class="feature-card">
          <div class="feature-icon">✨</div>
          <h3>美學舒壓</h3>
          <p>舒緩壓力，提升美感與健康，讓媽媽們重拾自信美麗</p>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped>
.home-page {
  min-height: 80vh;
}

.hero-section {
  background: linear-gradient(135deg, #f8e1e7 0%, #f3f3f3 100%);
  padding: 4rem 2rem;
  text-align: center;
  border-radius: 16px;
  margin-bottom: 3rem;
}

.hero-content {
  max-width: 800px;
  margin: 0 auto;
}

.hero-title {
  font-size: 3rem;
  color: #103b3c;
  margin-bottom: 1.5rem;
  font-weight: 700;
  letter-spacing: 2px;
}

.hero-subtitle {
  font-size: 1.3rem;
  color: #6c757d;
  margin-bottom: 2.5rem;
  line-height: 1.6;
}

.hero-actions {
  display: flex;
  gap: 1rem;
  justify-content: center;
  flex-wrap: wrap;
}

.cta-button {
  padding: 0.8rem 2rem;
  border-radius: 50px;
  text-decoration: none;
  font-weight: 600;
  transition: all 0.3s ease;
  display: inline-block;
}

.cta-button.primary {
  background: linear-gradient(135deg, #e9aebc 0%, #d16d8a 100%);
  color: white;
  box-shadow: 0 4px 15px rgba(233, 174, 188, 0.3);
}

.cta-button.primary:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(233, 174, 188, 0.4);
}

.cta-button.secondary {
  background: white;
  color: #e9aebc;
  border: 2px solid #e9aebc;
}

.cta-button.secondary:hover {
  background: #e9aebc;
  color: white;
  transform: translateY(-2px);
}

.features-section {
  padding: 3rem 0;
}

.features-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 2rem;
  max-width: 1200px;
  margin: 0 auto;
}

.feature-card {
  background: white;
  padding: 2.5rem 2rem;
  border-radius: 16px;
  text-align: center;
  box-shadow: 0 4px 20px rgba(233, 174, 188, 0.1);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.feature-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 8px 30px rgba(233, 174, 188, 0.15);
}

.feature-icon {
  font-size: 3rem;
  margin-bottom: 1.5rem;
}

.feature-card h3 {
  color: #103b3c;
  font-size: 1.5rem;
  margin-bottom: 1rem;
  font-weight: 600;
}

.feature-card p {
  color: #6c757d;
  line-height: 1.6;
}

@media (max-width: 768px) {
  .hero-title {
    font-size: 2.2rem;
  }
  
  .hero-subtitle {
    font-size: 1.1rem;
  }
  
  .hero-actions {
    flex-direction: column;
    align-items: center;
  }
  
  .cta-button {
    width: 200px;
  }
}
</style>


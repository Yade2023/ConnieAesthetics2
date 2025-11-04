/**
 * Zoom Effect 類別 - 模擬 jQuery cycle zoom 效果
 */
export class ZoomEffect {
  constructor(options = {}) {
    this.options = {
      minScale: options.minScale || 1,
      maxScale: options.maxScale || 1.2,
      speed: options.speed || 0.002,
      delay: options.delay || 0,
      fps: options.fps || 60,
      sync: options.sync !== undefined ? options.sync : true,
      ...options
    };
    
    this.scale = this.options.minScale;
    this.direction = 1;
    this.interval = null;
    this.isRunning = false;
  }

  start(elementId) {
    if (this.isRunning) return;
    
    const container = document.getElementById(elementId);
    const image = container?.querySelector('img') || container?.querySelector('.teacher-image');
    
    if (!image) {
      console.warn(`ZoomEffect: 找不到元素 #${elementId} 或其中的圖片`);
      return;
    }

    this.image = image;
    
    // 處理延遲
    const startDelay = Math.abs(this.options.delay);
    
    const startAnimation = () => {
      this.isRunning = true;
      
      this.interval = setInterval(() => {
        this.scale += this.direction * this.options.speed;
        
        // 檢查縮放範圍並改變方向
        if (this.scale >= this.options.maxScale) {
          this.direction = -1;
        } else if (this.scale <= this.options.minScale) {
          this.direction = 1;
        }
        
        // 應用縮放效果
        this.image.style.transform = `scale(${this.scale})`;
      }, 1000 / this.options.fps);
    };

    if (startDelay > 0) {
      setTimeout(startAnimation, startDelay);
    } else {
      startAnimation();
    }
  }

  stop() {
    if (this.interval) {
      clearInterval(this.interval);
      this.interval = null;
    }
    
    if (this.image) {
      this.image.style.transform = 'scale(1)';
    }
    
    this.isRunning = false;
  }

  pause() {
    if (this.interval) {
      clearInterval(this.interval);
      this.interval = null;
    }
    this.isRunning = false;
  }

  resume(elementId) {
    if (!this.isRunning && !this.interval) {
      this.start(elementId);
    }
  }
}

// 預設導出簡化的函數
export default function createZoomEffect(elementId, options = {}) {
  const zoomEffect = new ZoomEffect(options);
  zoomEffect.start(elementId);
  return zoomEffect;
}
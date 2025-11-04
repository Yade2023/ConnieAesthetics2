# Zoom Effect 使用說明

這個 Zoom 效果是為了模擬 jQuery cycle 插件的 zoom 功能而設計的純 JavaScript 實現。

## 基本用法

### 在 Vue 組件中使用

```javascript
import createZoomEffect from '../assets/js/zoomEffect.js';
import { onMounted, onUnmounted } from 'vue';

let zoomEffectInstance = null;

onMounted(() => {
  zoomEffectInstance = createZoomEffect('zoom', {
    fx: 'zoom',           // 效果類型
    sync: false,          // 非同步
    delay: 2000,          // 延遲2秒開始
    minScale: 1,          // 最小縮放比例
    maxScale: 1.15,       // 最大縮放比例  
    speed: 0.001,         // 縮放速度
    fps: 60               // 幀率
  });
});

onUnmounted(() => {
  if (zoomEffectInstance) {
    zoomEffectInstance.stop();
  }
});
```

### HTML 結構

```html
<div class="image-container" id="zoom">
  <img src="your-image.jpg" alt="描述" class="teacher-image">
</div>
```

## 參數說明

### createZoomEffect(elementId, options)

- **elementId**: 目標元素的 ID
- **options**: 配置選項物件

### Options 參數

| 參數 | 類型 | 默認值 | 說明 |
|------|------|--------|------|
| `fx` | string | 'zoom' | 效果類型（目前支援 zoom） |
| `sync` | boolean | true | 是否同步執行 |
| `delay` | number | 0 | 延遲開始時間（毫秒） |
| `minScale` | number | 1 | 最小縮放比例 |
| `maxScale` | number | 1.2 | 最大縮放比例 |
| `speed` | number | 0.002 | 縮放速度（每幀的縮放增量） |
| `fps` | number | 60 | 幀率 |

## 方法

### zoomEffectInstance.start(elementId)
啟動 zoom 效果

### zoomEffectInstance.stop()
停止 zoom 效果並重置縮放

### zoomEffectInstance.pause()
暫停 zoom 效果（保持當前縮放狀態）

### zoomEffectInstance.resume(elementId)
恢復 zoom 效果

## CSS 要求

確保目標容器有以下 CSS 樣式：

```css
.image-container {
  overflow: hidden;
  position: relative;
}

.teacher-image {
  transition: transform 0.1s ease-out;
  transform-origin: center center;
}
```

## jQuery cycle 對應關係

原 jQuery code:
```javascript
$('#zoom').cycle({ 
    fx: 'zoom', 
    sync: false, 
    delay: -2000 
});
```

對應的 Vue 實現:
```javascript
createZoomEffect('zoom', {
  fx: 'zoom',
  sync: false,
  delay: 2000  // 注意：正值表示延遲開始
});
```

## 注意事項

1. 確保目標元素在 DOM 中存在後再呼叫
2. 在組件卸載時記得停止效果以避免記憶體洩漏
3. `delay` 參數為正值時表示延遲開始，負值在原 jQuery 中有特殊含義，這裡統一處理為延遲時間
4. 效果會自動在最大和最小縮放之間循環
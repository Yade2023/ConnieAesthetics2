# 康妮泌乳美學 Connie Aesthetics

https://yade2023.github.io/ConnieAesthetics2

> 專業的孕期、產後護理及美體服務網站

## 📋 專案簡介

康妮泌乳美學是一個基於 Vue 3 和 Vite 開發的現代化單頁應用（SPA），提供專業的孕期護理、產後調理、放鬆療程等服務展示與預約功能。

### ✨ 主要功能

- 🏠 **首頁展示**：品牌介紹、服務亮點、客戶評價
- 💆 **服務項目**：
  - 孕期課程（孕婦按摩、孕期乳肩舒緩、產前乳腺保養）
  - 產後課程（子宮按摩、泌乳疏通、美式骨盆調理、腹直肌復位等）
  - 放鬆課程（艾草溫罐、女性按摩、美胸按摩等）
  - 攜伴課程（男性艾草溫罐、男性按摩等）
- 👩‍⚕️ **師資介紹**：專業團隊展示
- 📞 **聯絡預約**：服務諮詢與預約功能
- 🔝 **回到頂部**：使用人形圖示的滾動按鈕

### 🎨 設計特色

- 📱 完全響應式設計，支援桌面、平板、手機
- 🖼️ 圖片滿版顯示，不裁切不變形
- 🎯 7:3 圖文比例的服務卡片設計
- ✨ 流暢的過場動畫與懸停效果
- 🎨 粉色系溫馨配色方案

## 🛠️ 技術堆疊

### 核心框架
- **Vue 3** (v3.5.13) - 使用 Composition API
- **Vue Router** (v4.5.1) - 路由管理
- **Vite** (v6.2.4) - 快速建構工具

### 開發工具
- **@vitejs/plugin-vue** (v5.2.3) - Vue 插件支援
- **vite-plugin-vue-devtools** (v7.7.2) - Vue DevTools 整合

### 環境要求
- **Node.js**: v22.20.0
- **npm**: v10.9.3

## 📦 專案結構

```
connie-frontend/
├── public/                     # 靜態資源
│   ├── img/                   # 圖片資源
│   │   ├── 人形圖.png         # 回到頂部按鈕圖示
│   │   ├── 孕期/              # 孕期課程圖片
│   │   ├── 產後/              # 產後課程圖片
│   │   ├── 放鬆/              # 放鬆課程圖片
│   │   └── 客戶反饋/          # 客戶評價圖片
│   ├── logo/                  # Logo 圖片
│   └── iconn/                 # 圖標資源
├── src/
│   ├── assets/
│   │   ├── css/              # 樣式文件
│   │   ├── js/               # JavaScript 工具
│   │   └── json/             # 數據文件
│   │       └── 服務項目.json  # 服務項目數據
│   ├── components/           # Vue 組件
│   │   ├── card.vue          # 服務卡片組件
│   │   ├── ContactModal.vue  # 聯絡表單彈窗
│   │   ├── Footer.vue        # 頁尾組件
│   │   ├── navber.vue        # 導航欄組件
│   │   ├── ScrollToTop.vue   # 回到頂部按鈕
│   │   └── News.vue          # 最新消息組件
│   ├── views/                # 頁面視圖
│   │   ├── homeViews.vue     # 首頁
│   │   ├── servicesViews.vue # 服務頁面
│   │   └── teachersViews.vue # 師資頁面
│   ├── router/               # 路由配置
│   │   └── index.js
│   ├── App.vue               # 根組件
│   └── main.js               # 入口文件
├── dist/                     # 建構輸出目錄
├── vite.config.js            # Vite 配置
├── package.json              # 專案配置
└── README.md                 # 專案說明

```

## 🚀 快速開始

### 1. 安裝依賴

```sh
npm install
```

### 2. 開發模式

啟動本地開發伺服器（支援熱重載）：

```sh
npm run dev
```

開發伺服器將運行在 `http://localhost:5173/ConnieAesthetics2/`

### 3. 生產建構

建構優化後的生產版本：

```sh
npm run build
```

建構文件將輸出到 `dist/` 目錄

### 4. 預覽建構結果

預覽生產建構版本：

```sh
npm run preview
```

## ⚙️ 配置說明

### Vite 配置 (vite.config.js)

```javascript
{
  base: '/ConnieAesthetics2/',  // GitHub Pages 部署路徑
  plugins: [vue(), vueDevTools()],
  resolve: {
    alias: { '@': './src' }      // @ 別名指向 src 目錄
  }
}
```

### 路由模式

- **本地開發**：使用 HTML5 History 模式
- **GitHub Pages**：自動切換為 Hash 模式
- 支援的路由：
  - `/` - 首頁
  - `/services` - 服務項目
  - `/teachersViews` - 師資介紹

## 🎯 核心組件說明

### ScrollToTop 組件
- 滾動超過 300px 時自動顯示
- 點擊平滑滾動回到頂部
- 使用自訂人形圖示
- 支援淡入淡出動畫

### Card 組件
- 7:3 圖文比例設計
- 圖片滿版顯示不裁切
- 漸層背景美化空白區域
- 響應式自適應佈局

### ContactModal 組件
- 服務諮詢彈窗
- 表單驗證功能
- ESC 鍵快速關閉

## 📱 響應式斷點

```css
- 桌面版: > 991px
- 平板版: 768px - 991px
- 手機版: 480px - 768px
- 小型手機: < 480px
```

## 📚 相關文件

- [圖片偵錯指南](IMAGE_DEBUG_GUIDE.md)
- [響應式設計指南](RESPONSIVE_DESIGN_GUIDE.md)
- [服務整合指南](SERVICE_INTEGRATION_GUIDE.md)
- [縮放效果說明](ZOOM_EFFECT_README.md)
- [優化總結](OPTIMIZATION_SUMMARY.md)

## 🔧 開發工具推薦

### IDE 設定
- [VSCode](https://code.visualstudio.com/)
- [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) - Vue 3 官方擴充
- 請停用 Vetur（與 Volar 衝突）

### 推薦 VSCode 擴充
- Vue - Official (Volar)
- ESLint
- Prettier - Code formatter
- Path Intellisense

## 🌐 部署

### GitHub Pages 部署

專案已配置為可直接部署到 GitHub Pages：

1. 執行建構：`npm run build`
2. `dist/` 目錄即為部署文件
3. 確保 `base` 路徑設定正確：`/ConnieAesthetics2/`

### 其他平台部署

如需部署到其他平台（Netlify、Vercel 等），請修改 `vite.config.js` 中的 `base` 設定。

## 📄 授權

Private - 康妮泌乳美學專屬

## 👥 團隊

- **開發者**: 徐承杰
- **專案名稱**: ConnieAesthetics2
- **擁有者**: Yade2023

## 📞 聯絡資訊

如有任何問題或建議，歡迎透過網站聯絡表單與我們聯繫。

---

**最後更新**: 2025年11月13日

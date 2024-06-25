import { createApp } from 'vue'
import App from '@/App.vue'
import router from '@/router/index.ts'
import ElementPlus from 'element-plus'
import * as Icons from '@element-plus/icons-vue';
import '@/assets/style/global.css';
import 'element-plus/dist/index.css'


const app = createApp(App)

app.use(ElementPlus)
// 全局注册所有图标组件
for (const [key, component] of Object.entries(Icons)) {
  app.component(key, component);
}
app.use(router)

app.mount('#app')
import { createRouter, createWebHashHistory } from 'vue-router';

const routes = [
 {
    path: '/',
    redirect: '/login',
  },
  {
    path: '/login',
    component: () => import('@/components/Login.vue'),
    key: 'login'
  },
  {
    path: '/Blog',
    component: () => import('@/components/Blog.vue'),
  }
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
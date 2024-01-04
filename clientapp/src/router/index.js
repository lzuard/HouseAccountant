import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MainPage from '@/pages/MainPage.vue'
import GridPage from '@/pages/GridPage.vue'
import UploadPage from '@/pages/UploadPage.vue'

const routes = [
  {
    path: '/home',
    name: 'home',
    component: HomeView
    },
  {
        path: '/',
        name: 'main-page',
        component: MainPage
    },
    {
        path: '/GridPage',
        name: 'grid-page',
        component: GridPage
    },
    {
        path: '/UploadPage',
        name: 'uplaod-page',
        component: UploadPage
    },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
    }
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

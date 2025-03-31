// router.js
 

import { createWebHistory, createRouter } from 'vue-router'
import Search from './components/Search.vue'
import SearchHistoryDaily from './components/SearchHistoryDaily.vue'
import SearchHistoryWeekly from './components/SearchHistoryWeekly.vue' 

 

 
const routes = [
  
  { path:   '/', component: Search },
  { path: '/daily', component: SearchHistoryDaily },
  { path: '/weekly', component: SearchHistoryWeekly }
];
 

const router = createRouter({
  history: createWebHistory(),
  routes 
})

export default router

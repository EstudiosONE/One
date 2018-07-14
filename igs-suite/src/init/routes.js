import OnePageMain from "../pages/main.vue"
import OnePageHotel from "../pages/hotel/dashboard.vue"
import OnePageError404 from "../pages/error/404.vue"

const routes = [
  { path: '/', component: OnePageMain },
  // Módulos

    // Hotel
    { path: '/hotel', component : OnePageHotel },
    { path: '/hotel/reservation/:id/view', component : OnePageHotel },

  // Errors
  { path: '*', component: OnePageError404}
]

export default routes

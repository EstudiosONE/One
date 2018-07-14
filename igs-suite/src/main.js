import Vue from 'vue'
import VueRouter from 'vue-router'
import store from './vuex/store.js'
import App from './App.vue'

// Componentes
import OneHeader from "./components/header.vue"
import OneMenu from "./components/menu.vue"
import OneFooter from "./components/footer.vue"
import OneButtonSquad48 from "./components/btn-squad-48.vue"

Vue.component( 'one-header', OneHeader )
Vue.component( 'one-menu', OneMenu )
Vue.component( 'one-footer', OneFooter )
Vue.component( 'one-button-squad-48', OneButtonSquad48 )

// Iconos
import icons from './init/components/icons'
icons()

// Router
import router from './init/router'

// App
new Vue({
  el: '#app',
  render: h => h(App),
  store,
  router
})

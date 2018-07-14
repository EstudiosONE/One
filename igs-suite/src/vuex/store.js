import Vue from 'vue'
import Vuex from 'vuex'

import system from './system/system'

Vue.use(Vuex)

const state = {
  user: {
    name: "Rose Mary",
    surname: "Blanco",
    position: "Recepcionista",
    sex: "F",
    profilePicture: ""
  }
}
const getters = {
  getUser: state => state.user
}
const modules = {
  system
}

export default new Vuex.Store({
  state,
  getters,
  modules
})

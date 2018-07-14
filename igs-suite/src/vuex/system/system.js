const auth = {
  namespaced: true,
  state: {
    user: {
      name: "Diego"
    }
  },
  getters: {
    getActiveUser: state => {
      return state.user
    }
  }
}


const system = {
  namespaced: true,
  getters: {

  },
  modules: {
    auth
  }
}


export default system

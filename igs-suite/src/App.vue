<template lang="pug">
  #App.o-app
    #Base.o-base
      router-view.o-navigator
      one-header.o-header
      one-menu.o-menu
      one-footer.o-footer
    #PopUp
</template>

<script>
export default {
  name: 'app',
  components: {
  },
}
</script>

<style lang="scss">
a:-webkit-any-link{
  text-decoration: none;
}
</style>

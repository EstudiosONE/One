<template lang="pug">
  #404
    #content
      #icon
        one-icons-error-404.icon-192
      #text
        h1 Upss!!!
        p No pudimos encontrar ésta página
</template>

<script>
export default {
}
</script>

<style scoped lang="scss">
@import 'src/styles/colors';
.o-navigator{
  justify-content: center;
  align-items: center;
}
#content{
  display: grid;
  grid-template-columns: 196px auto;
  grid-template-rows: 196px;
  #text{
    margin-left: 48px;
    h1{
      font-size: 55px;
      margin: 36px 0 0 0;
      color: $clr-blue;
    }
  }
}
</style>

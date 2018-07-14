<template lang="pug">
  #main
    #hello
      p.o-text-hello Hola, {{ user }} ;-)
      p.o-text-hello-sub que bueno verte aquí nuevamente!!!
    #info
      router-link(to="/help/alert/printserver").alert No podemos comunicarnos con el servidor de impresión
      br
      router-link(to="/help/alert/Paradise").alert No podemos comunicarnos con el gateway en {{ gateway }}
</template>

<script>
export default {
  computed: {
    user: function() {
      const user = this.$store.getters['system/auth/getActiveUser']
      return user.name
    },
    gateway: function() {
      return '"SERVER01"'
    }
  }
}
</script>

<style scoped lang="scss">
@import 'src/styles/colors';
.box {
  position: relative;
}
.box:hover::after {
  content: "+";
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%,-50%);
  color: white;
  font-size: 60px;
  font-weight: bold;
}
#main {
    display: grid;
    grid-template-columns: 60px auto 1fr;
    grid-template-rows: 72px 1fr 0.25fr;
}
#hello {
    grid-area: 2 / 2 / span 1 / span 1;
    #container {
        margin: 2vw 0 0;
        width: 80vw;
        max-width: 85vw;
        height: auto;
        max-height: 20vw;
        display: grid;
        grid-auto-flow: row;
        grid-template-columns: repeat(auto-fit, minmax(10vw, 10vw));
        grid-template-rows: repeat(auto-fit, minmax(10vw, 10vw));
        border-radius: 8px;
        background-color: $clr-white;
        overflow: hidden;
        border-style: solid;
        border-width: 1px;
        border-color: $clr-grey-300;
        position: relative;
        .oo-button-square {
            top: -1px;
            right: -1px;
            bottom: -1px;
            left: -1px;
            width: 8vw;
            height: 8vw;
            padding: 1vw;
            border: 1px solid $clr-grey-300;
            fill: $clr-blue;
            svg {
                width: 2vw;
                height: 2vw;
                margin: 2.2vw 3vw 0.8vw;
            }
            p {
                margin: 0 auto;
                text-align: center;
                font-size: 1.2vw;
                overflow: hidden;
                text-overflow: ellipsis;
            }
        }
        .oo-button-square:hover {
            background-color: $clr-blue;
            fill: $clr-white;
            color: $clr-white;
        }
    }
}
#info {
    grid-area: 3 / 2 / span 1 / span 1;
}
</style>

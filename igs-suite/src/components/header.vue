<template lang="pug">
#header
  .o-button-hamburguer
    one-icons-menu.icon
  .o-title-logo-header
    one-icons-corp-igs.icon
  .o-title-header
    span
      label(style="font-weight: 400;") iGS &nbsp
      label(style="font-weight: 100;") Suite
  .o-user-header
    .img
      one-icons-circle-user-male(v-if="profilePicture == '' & sex === 'M'")
      one-icons-circle-user-famale(v-if="profilePicture == '' & sex === 'F'")
      img(:src="profilePicture", v-if="profilePicture != ''")
    h1 {{ user }}
    h2 {{ position }}
    one-button-squad-48.icon-s
      one-icons-menu-vertical(slot="icon")
</template>

<script>
export default {
  name: "one-header",
  computed: {
    user: function() {
      const user = this.$store.getters.getUser
      return `${user.name} ${user.surname}`
    },
    position: function() {
      const user = this.$store.getters.getUser
      return user.position
    },
    profilePicture: function() {
      const user = this.$store.getters.getUser
      return user.profilePicture
    },
    sex: function(){
      const user = this.$store.getters.getUser
      return user.sex
    }
  }

}
</script>

<style lang="scss">
@import 'src/styles/colors.scss';

#header {
    display: grid;
    grid-template-rows: 72px;
    grid-template-columns: 72px 48px 12px 1fr 248px;
    .o-user-header {
        grid-area: 1 / 6 / 2 / span 1;
    }
    .o-button-hamburguer{
      fill: $clr-grey-600;
      grid-area: 1 / 1 / 2 / span 1;
      width: 48px;
      height: 48px;
      margin: 8px 12px;
      border-radius: 50%;
      .icon{
        width: 24px;
        height: 24px;
        padding: 12px;
      }
    }
    .o-title-logo-header{
      fill: $clr-grey-600;
      grid-area: 1 / 2 / 2 / span 1;
      width: 48px;
      height: 48px;
      margin: 8px 0;
      border-radius: 50%;
      .icon{
        width: 48px;
        height: 48px;
        padding: 0px;
      }
    }
    .o-button-hamburguer:hover{
      background-color: $clr-grey-50;
    }
    .o-title-header{
      grid-area: 1 / 4 / 2 / span 1;
      height: 25px;
      padding: 19.5px 0;
      font-size: 23px;
      color: $clr-grey-600;
      span{
      }
    }
    .o-user-header{
    }
}
</style>

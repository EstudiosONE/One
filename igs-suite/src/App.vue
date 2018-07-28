<template lang="pug">
  #App.o-app
    #Base.o-base
      router-view.o-navigator
      one-header.o-header
      one-menu.o-menu
      one-footer.o-footer
    #PopUp
    .mdc-snackbar.mdc-snackbar--align-start(aria-live="assertive", aria-atomic="true", aria-hidden="true")
      .mdc-snackbar__text
      .mdc-snackbar__action-wrapper
        button.mdc-snackbar__action-button
</template>

<script>
import {MDCSnackbar} from '@material/snackbar';

export default {
  name: 'app',
  mounted() {
    const snackbar = new MDCSnackbar(document.querySelector('.mdc-snackbar'));
    const dataObj = {
      message: "Reserva confirmada correctamente",
    };
        snackbar.show(dataObj);
  },
  components: {
  },
}
</script>

<style lang="scss">
@import "@material/button/mdc-button";
@import "@material/snackbar/mdc-snackbar";

a:-webkit-any-link{
  text-decoration: none;
}
</style>

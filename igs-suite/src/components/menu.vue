<template lang="pug">
#menu
    .options
        router-link(to="/hotel" tag="div").button
            button.mdc-button
                one-icons-hotel.icon
        router-link(to="/restaurant" tag="div").button
            button.mdc-button
                one-icons-restaurant.icon
        router-link(to="/management" tag="div").button
            button.mdc-button
                one-icons-management.icon



</template>

<script>
import { MDCRipple } from "@material/ripple";

export default {
  mounted() {
    const ripple = new MDCRipple(document.querySelector(".mdc-button"));
  }
};
</script>

<style scoped lang="scss">
@import "src/styles/colors.scss";
@import "@material/button/mdc-button";

.options {
    .button {
        height: 48px;
        width: 72px;
        margin: 12px 0;
        .mdc-button {
            border-radius: 0 24px 24px 0;
            height: 48px;
            width: 72px;
            position: relative;
            .icon {
                fill: $clr-grey-600;
                width: 24px;
                height: 24px;
            }
        }
    }
  .button:hover {
    background-color: $clr-grey-50;
  }
  .router-link-active {
      .mdc-button{
background-color: $clr-blue-50;
      }
    
    .icon {
      fill: $clr-blue;
    }
  }
}
</style>

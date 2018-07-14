<template lang="pug">
  .restaurant
    .restaurant-menu
      .restaurant-menu-content
        router-link(to="/restaurant" exact tag="div").button
          one-icons-restaurant-table
          p Mesas
        router-link(to="/restaurant/reservations" tag="div").button
          one-icons-restaurant-reservation
          p Reservas
        router-link(to="/restaurant/reports" tag="div").button
          one-icons-import
          p Informes
    router-view.dashboard
</template>

<script>
export default {
  methods: {
    viewRoute: function(id) {
      return `/hotel/reservation/${id}/view`;
    },
    editRoute: function(id) {
      return `/hotel/reservation/${id}/edit`;
    },
    checkInRoute: function(id) {
      return `/hotel/reservation/${id}/checkin`;
    }
  },
  data() {
    return {
      reservations: []
    };
  }
};
</script>

<style lang="scss">
@import "src/styles/colors.scss";
@import "src/styles/elevation.scss";
.restaurant {
  grid-template-columns: 60px 1fr 8px;
  grid-template-rows: 60px 1fr 8px;
  overflow: hidden;
  .dashboard{
    grid-area: 2 / 2 / span 1 / span 1;
  }
}
.restaurant-menu {
  grid-area: 1 / 2 / span 1 / span 2;  
  border-bottom: solid 1px $clr-grey-200;
}
.restaurant-menu-content {
  display: grid;
  grid-auto-columns: 148px;
  grid-auto-flow: column;
  height: 48px;
  width: fit-content;
  margin: 12px 0px 0px 0px;
  overflow: hidden;
  fill: $clr-grey-600;
  color: $clr-grey-600;
  .button {
    height: 48px;
    display: grid;
    grid-template-rows: 44px 4px;
    grid-template-columns: 48px 100px;
    cursor: pointer;
    svg {
      width: 24px;
      margin: 10px 8px;
    }
    p {
      width: 108px;
      margin: auto 0px;
      font-size: 12px;
      font-weight: bold;
    }
  }
  .button::before{
    border-top-left-radius: 3px;
    border-top-right-radius: 3px;
    grid-column: 1 / span 2;
    grid-row: 2 / span 1;
    content: ' ';
    height: 3px;
    margin: 1px 8px 0 8px;
    right: 0;
  }
  .button:hover {
    background-color: $clr-grey-300;
  }
  .router-link-active {
    color: $clr-blue;
    fill: $clr-blue;
  }
  .router-link-active::before{
    background-color: $clr-blue;
  }
}
.dashboard {
  grid-area: 2 / 2 / span 1 / span 1;
}
</style>

<template lang="pug">
  .hotel
    .hotel-menu
      .hotel-menu-content
        router-link(to="/hotel/reservation/add" tag="div").button
          one-icons-add
          p Nueva reserva
        router-link(to="/hotel/reservation/import" tag="div").button
          one-icons-import
          p Importar reservas
        router-link(to="/hotel/report/interpol" tag="div").button
          one-icons-interpol
          p Informe INTERPOL
    .dashboard
      .dash-reservation
        .dash-reservation-title
          h2 Reservas para hoy
          one-icons-menu-vertical.button
        .dash-reservation-list
          .reservation-item(v-for="reservation in reservations")
            p {{reservation.room}}
            p {{reservation.pax}}
            p {{reservation.adults}}
            p {{reservation.childrens}}
            p {{reservation.babies}}
            p {{reservation.pension}}
            P {{reservation.state}}
            .actions
              router-link(:to="viewRoute(reservation.id)" tag="div")
                one-icons-view
              router-link(:to="editRoute(reservation.id)" tag="div")
                one-icons-edit
              router-link(:to="checkInRoute(reservation.id)" tag="div")
                one-icons-check-in
              one-icons-menu-vertical
      .dash-reservation
        .dash-reservation-title
          h2 Reservas para mañana
          one-icons-menu-vertical.button
</template>

<script>
export default {
  methods:{
    viewRoute: function(id){
      return `/hotel/reservation/${id}/view`
    },
    editRoute: function(id){
      return `/hotel/reservation/${id}/edit`
    },
    checkInRoute: function(id){
      return `/hotel/reservation/${id}/checkin`
    }
  },
  data() {
    return {
      reservations: [{
          id: 245665,
          room: 'Santiago',
          pax: 'RODRIGUEZ, JUAN',
          adults: 2,
          childrens: 0,
          babies: 0,
          pension: 'Desayuno incluido',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
        {
          id: 445555,
          room: 'San Felipe',
          pax: 'PEREZ, GONZALO',
          adults: 1,
          childrens: 2,
          babies: 0,
          pension: 'Pensión completa',
          state: 'Reservada'
        },
      ]
    }
  }
}
</script>

<style lang="scss">
@import 'src/styles/colors.scss';
@import 'src/styles/elevation.scss';
.hotel {
    grid-template-columns: 60px 1fr 8px;
    grid-template-rows: 60px 1fr 8px;
    overflow: hidden;
}
.hotel-menu {
    grid-area: 1 / 2 / span 1 / span 1;
}
.dashboard {
  overflow-y: auto;
  .dash-reservation {
    .dash-reservation-title {
      margin-top: 12px;
      display: grid;
      grid-template-columns: auto 48px 1fr;
      grid-auto-rows: 48px;
      grid-auto-flow: column;
      grid-gap: 12px;
      align-items: center;
      color: $clr-grey-600;
      fill: $clr-grey-600;
      h2 {
        position: relative;
        font-size: 21px;
        font-weight: 100;
        width: auto;
      }
      .button {
        border-radius: 24px;
        width: 24px;
        padding: 12px;
      }
      .button:hover {
        background-color: $clr-grey-50;
      }
    }
    .dash-reservation-list {
      .reservation-item {
        display: grid;
        grid-template-columns: 148px 196px repeat(3, 48px) 196px 148px 1fr;
        grid-template-rows: 48px;
        padding: 0 12px;
        p {
          color: $clr-grey-600;
        }
        .actions {
          display: grid;
          grid-auto-columns: 40px;
          grid-template-rows: 32px;
          grid-gap: 1px;
          grid-auto-flow: column;
          width: fit-content;
          height: 32px;
          margin: 8px;
          border-radius: 16px;
          @include mdElevation(2);
          overflow: hidden;
          svg {
            background-color: $clr-white;
            fill: $clr-grey-600;
            cursor: pointer;
            width: 24px;
            padding: 4px 8px;
            outline: 1px solid $clr-grey-300;
          }
        }
      }
      .reservation-item:hover {
          background-color: $clr-grey-50;
      }
    }
  }
}
.hotel-menu-content {
    display: grid;
    grid-gap: 1px;
    grid-auto-columns: 148px;
    grid-auto-flow: column;
    height: 48px;
    width: fit-content;
    margin: 12px 0;
    border-radius: 24px;
    @include mdElevation(2);
    overflow: hidden;
    fill: $clr-grey-600;
    color: $clr-grey-600;
    .button {
        height: 48px;
        outline: 1px solid $clr-grey-300;
        cursor: pointer;
        svg {
            width: 24px;
            margin: 2px 64px;
        }
        p {
            width: 124px;
            padding: 0 12px;
            text-align: center;
            margin-top: 0;
            font-size: 12px;
        }
    }
    .button:hover {
        background-color: $clr-grey-50;
    }
}
.dash-reservation {}
.dashboard {
    grid-area: 2 / 2 / span 1 / span 1;

}
</style>
